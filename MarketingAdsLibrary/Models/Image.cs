using System.ComponentModel.DataAnnotations.Schema;

namespace MarketingAds.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public int? ListingID { get; set; }
        public string? ImageURL { get; set; }

        [ForeignKey("ListingID")]
        public Listing? Listing { get; set; }
        public int StatusId { get; set; } = 1;
        [ForeignKey("StatusId")]
        public virtual Status? Status { get; set; }
    }

}
