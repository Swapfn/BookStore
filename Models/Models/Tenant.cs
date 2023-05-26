namespace Models.Models
{
    public class Tenant
    {
        public string TenantId { get; set; }
    }
    public interface ITenantService
    {
        void SetTenant(string tenantId);
        string TenantId { get; }
        public string GetNewTenantId();
    }
    public class TenantService : ITenantService
    {
        public string TenantId { get; private set; }

        public void SetTenant(string tenantId)
        {
            TenantId = tenantId;
        }
        public string GetNewTenantId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
