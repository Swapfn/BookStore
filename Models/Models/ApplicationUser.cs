using Microsoft.AspNetCore.Identity;

namespace Models.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string FullName => FirstName + LastName;
        public int CityID { get; set; }
        public int CountryID { get; set; }
        public DateTime LastLogin { get; set; }
        public string? RegisterIPAddress { get; set; }
        public string? LoginIPAddress { get; set; }
        public DateTime RegisterationDate { get; set; }
        public string TenantId { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
        public ICollection<ApplicationToken> UserTokens { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public ApplicationUser()
        {
            UserRoles = new HashSet<ApplicationUserRole>();
            UserTokens = new List<ApplicationToken>();
            Reviews = new List<Review>();
        }
    }
}
