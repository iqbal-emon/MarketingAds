using System.ComponentModel.DataAnnotations.Schema;

namespace MarketingAds.Models
{
    public class Message
    {
        public int? MessageID { get; set; }
        public int? SenderID { get; set; }
        public int? ReceiverID { get; set; }
        public int? ListingID { get; set; }
        public string? MessageContent { get; set; }
        public DateTime? SentDate { get; set; }

        [ForeignKey("SenderID")]
        public User? Sender { get; set; }
        [ForeignKey("ReceiverID")]
        public User? Receiver { get; set; }
        [ForeignKey("ListingID")]
        public Listing? Listing { get; set; }
        public int? StatusId { get; set; } = 1;
        [ForeignKey("StatusId")]
        public virtual Status? Status { get; set; }
    }

}
