using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services.Contracts;

namespace WebAPI.Controllers
{
    public class AuthController : BaseController
    {
        public IAuthService _authService { get; }
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            return await _authService.LoginAsync(model);
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            return await _authService.RegisterAsync(model);
        }

        [HttpPost]
        [Route("/refreshToken")]
        public async Task<IActionResult> RefreshsToken(string token)
        {
            return await _authService.RefreshTokenAsync(token);
        }
    }
}
