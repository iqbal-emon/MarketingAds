using System.ComponentModel.DataAnnotations.Schema;

namespace MarketingAds.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int? ListingID { get; set; }
        public int? ReviewerID { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime?  ReviewDate { get; set; }

        [ForeignKey("ListingID")]
        public Listing? Listing { get; set; }
        [ForeignKey("ReviewerID")]
        public User? Reviewer { get; set; }
        public int StatusId { get; set; } = 1;
        [ForeignKey("StatusId")]
        public virtual Status? Status { get; set; }
    }

}
