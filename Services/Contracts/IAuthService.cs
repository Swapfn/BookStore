using Microsoft.AspNetCore.Mvc;
using Models.DTO;

namespace Services.Contracts
{
    public interface IAuthService
    {
        public Task<IActionResult> RegisterAsync(RegisterDTO model);
        public Task<IActionResult> LoginAsync(LoginDTO model);
        public Task<IActionResult> RefreshTokenAsync(string token);
    }
}
