using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Transactions;

namespace MarketingAds.Models
{
    public class User
    {
      
        public int UserID { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public DateTime?  RegistrationDate { get; set; }
        public string? UserRole { get; set; }

        public ICollection<Listing> Listings { get; set; }
        public ICollection<Message> MessagesSent { get; set; }
        public ICollection<Message> MessagesReceived { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public int StatusId { get; set; } = 1;
        [ForeignKey("StatusId")]
        public virtual Status? Status { get; set; }
    }
}
