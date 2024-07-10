using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketingAds.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        
       
        //public ICollection<Listing>? Listings { get; set; }

        public int StatusId { get; set; } = 1;
        [ForeignKey("StatusId")]
        public virtual Status? Status { get; set; }
    }
}
