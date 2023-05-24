namespace Models.Models
{
    public class Tenant
    {
        public string TenantId { get; set; } = null!;
    }
    public interface ITenantService
    {
        void SetTenant(string tenantId);
        string TenantId { get; }
        public string GetTenant();
    }
    public class TenantService : ITenantService
    {
        public string TenantId { get; private set; } = null!;

        public void SetTenant(string tenantId)
        {
            TenantId = tenantId;
        }
        public string GetTenant()
        {
            return TenantId;
        }
    }
}
