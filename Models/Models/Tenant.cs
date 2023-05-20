namespace Models.Models
{
    public class Tenant
    {
        public string TenantId { get; set; } = null!;
        public string TenantName { get; set; } = null!;
    }
    public interface ITenantService
    {
        void SetTenant(string tenantName);
        string TenantName { get; }
    }

    public class TenantService : ITenantService 
    {
        public string TenantId { get; private set; } = null!;
        public string TenantName { get; private set; } = null!;

        public void SetTenant(string tenantName)
        {
            TenantId = Guid.NewGuid().ToString();
            TenantName = tenantName;
        }
    }
}
