using System.ComponentModel.DataAnnotations.Schema;

namespace MarketingAds.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int? ListingID { get; set; }
        public int? BuyerID { get; set; }
        public int? SellerID { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? Amount { get; set; }
        public string? Status { get; set; }

        [ForeignKey("ListingID")]
        public Listing? Listing { get; set; }
        [ForeignKey("BuyerID")]
        public User? Buyer { get; set; }
        [ForeignKey("SellerID")]
        public User? Seller { get; set; }
        public int StatusId { get; set; } = 1;
        [ForeignKey("StatusId")]
        public virtual Status? Statuss { get; set; }
    }

}
