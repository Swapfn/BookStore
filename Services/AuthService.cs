using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.DTO;
using Models.Models;
using Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
/*
 *
 * Note
 https://learn.microsoft.com/en-us/aspnet/core/fundamentals/target-aspnetcore?view=aspnetcore-6.0&tabs=visual-studio#use-the-aspnet-core-shared-framework
 */
namespace Services
{
    public class AuthService : ControllerBase, IAuthService
    {
        readonly ITokenService _tokenService;
        readonly UserManager<ApplicationUser> _userManager;
        readonly RoleManager<ApplicationRole> _roleManager;
        readonly IHttpContextAccessor _context;

        public AuthService(ITokenService tokenService, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IHttpContextAccessor context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _tokenService = tokenService;
        }
        public async Task<IActionResult> LoginAsync(LoginDTO model)
        {
            // Check if user exists
            ApplicationUser? user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
                return NotFound(new { Status = "Error", Message = "User Doesn't Exists" });
            // Login
            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                IList<string> roles = await _userManager.GetRolesAsync(user);
                SecurityToken token = await _tokenService.CreateToken(user, roles, _roleManager);
                ApplicationToken? refreshToken;
                // Create Refresh Token
                if (user.UserTokens.Any(t => t.IsActive))
                {
                    refreshToken = user.UserTokens.FirstOrDefault(t => t.IsActive);

                }
                else
                {
                    refreshToken = await GenerateRefreshToken(user, roles, _roleManager);
                    user.UserTokens.Add(refreshToken);
                }
                //IHttpConnectionFeature feature = _context.HttpContext.Features.Get<IHttpConnectionFeature>();
                user.LoginIPAddress = _context.HttpContext.Connection.RemoteIpAddress.ToString();
                user.LastLogin = DateTime.UtcNow;
                await _userManager.UpdateAsync(user);
                return Ok(refreshToken);
            }
            // Incorrect Credentials
            return Unauthorized(new { Status = "Error", Message = "Incorrect Username / Password" });
        }

        public async Task<IActionResult> RefreshTokenAsync(string token)
        {
            ApplicationUser? user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserTokens.Any(t => t.RefreshToken == token));
            IList<string> roles = await _userManager.GetRolesAsync(user);
            if (user == null)
                return NotFound(new { Message = "User Not Found" });
            ApplicationToken? refreshToken = user.UserTokens.Single(ut => ut.RefreshToken == token);
            if (!refreshToken.IsActive)
                return NotFound(new { Message = "Inactive Token" });
            refreshToken.RevokedOn = DateTime.UtcNow;
            ApplicationToken? newRefreshToken = await GenerateRefreshToken(user, roles, _roleManager);
            user.UserTokens.Add(newRefreshToken);
            await _userManager.UpdateAsync(user);
            return Ok(newRefreshToken);
        }

        public async Task<IActionResult> RegisterAsync(RegisterDTO model)
        {
            ApplicationUser? user = await _userManager.FindByNameAsync(model.UserName);
            // Check if the user exists
            if (user != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User Already Exists!" });

            user = new()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                LastLogin = DateTime.UtcNow,
                PhoneNumber = model.MobileNumber,
                RegisterIPAddress = _context.HttpContext.Connection.LocalIpAddress.ToString(),
                RegisterationDate = DateTime.UtcNow,
                SecurityStamp = Guid.NewGuid().ToString(),
                TenantId = Guid.NewGuid().ToString(),
                TenantName = model.TenantName,
            };

            IdentityResult resultUser = await _userManager.CreateAsync(user, model.Password);
            if (!resultUser.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = resultUser.Errors });
            // Bind User to roles
            IdentityResult resultRole = await _userManager.AddToRoleAsync(user, nameof(User));
            if (!resultRole.Succeeded && !resultUser.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User Creation Failed" });
            return Created("", new { Status = "OK", Messasge = "User Created Successfuly" });
        }

        async Task<ApplicationToken> GenerateRefreshToken(ApplicationUser user, IList<string> roles, RoleManager<ApplicationRole> roleManager)
        {
            byte[] randomNumber = new byte[64];
            RandomNumberGenerator.Create().GetBytes(randomNumber);
            string refreshToken = Convert.ToBase64String(randomNumber);
            Task<SecurityToken> token = _tokenService.CreateToken(user, roles, roleManager);
            return new ApplicationToken
            {
                RefreshToken = refreshToken,
                Token = new JwtSecurityTokenHandler().WriteToken(await token),
                ExpiresOn = DateTime.UtcNow.AddDays(3),
                CreatedOn = DateTime.UtcNow,
            };
        }
    }
}
