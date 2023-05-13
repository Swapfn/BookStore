using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Models;
using Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class TokenService : ITokenService
    {
        readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration configuration) => _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"] ?? ""));
        public async Task<SecurityToken> CreateToken(ApplicationUser user, IList<string> roles, RoleManager<ApplicationRole> roleManager)
        {
            SecurityTokenDescriptor tokenDescriptor = await GetTokenDescriptor(user, roles, roleManager);
            JwtSecurityTokenHandler tokenHandler = new();
            return tokenHandler.CreateToken(tokenDescriptor);
        }

        private async Task<SecurityTokenDescriptor> GetTokenDescriptor(ApplicationUser user, IList<string> roles, RoleManager<ApplicationRole> roleManager)
        {
            // Claims
            List<Claim> authClaims = new()
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
            };

            // Role Claims
            foreach (var item in roles)
            {
                ApplicationRole? role = await roleManager.FindByNameAsync(item.ToString());
                authClaims.Add(new Claim(ClaimTypes.Role, role.Id.ToString()));
            }

            // Create Token Descriptor
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(authClaims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature),
                Audience = "Client",
                Issuer = "Server",
            };

            // Return Tokens
            return tokenDescriptor;
        }
    }
}
