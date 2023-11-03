using Microsoft.Identity.Web;
using Models.Models;
using System.Security.Claims;

namespace WebAPI
{
    public class TenantMiddleware : IMiddleware
    {
        private readonly ITenantService _tenantService;
        private readonly ILogger<TenantMiddleware> _logger;
        public TenantMiddleware(ITenantService tenantService, ILogger<TenantMiddleware> logger)
        {
            _tenantService = tenantService;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            ClaimsIdentity? identity = context.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                // or
                //identity.FindFirst("ClaimName").Value;
                // get claim
                string? tenantId = claims.FirstOrDefault(c => c.Type == ClaimConstants.TenantId)?.Value;
                _tenantService.SetTenant(tenantId);
            }
            await next(context);
        }
    }
}
