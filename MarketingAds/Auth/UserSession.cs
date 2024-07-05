using System.Data;

namespace MarketingAds.Auth
{
    public class UserSession
    {
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
        public bool IsAuthenticated { get; set; }
    }
}
