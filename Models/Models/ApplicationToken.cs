using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Models.Models
{
    [Owned]
    public class ApplicationToken
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresOn { get; set; }
        public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
        public DateTime CreatedOn { get; set; }
        public DateTime? RevokedOn { get; set; }
        [JsonIgnore]
        public bool IsActive => RevokedOn == null && !IsExpired;
    }
}
