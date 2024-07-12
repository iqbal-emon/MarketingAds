using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketingAds.Models
{
    public class Listing
    {
        public int ListingID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryID { get; set; }
        public int? LocationID {  get; set; }
        public int? UserID { get; set; }
        public string? Condition { get; set; }
        public DateTime? PostedDate { get; set; }
  
        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }

        [ForeignKey("UserID")]
        public User? User { get; set; }

        [ForeignKey("LocationID")]
        public Location? Location { get; set; }
        public ICollection<Image>? Images { get; set; }
        //public ICollection<Review>? Reviews { get; set; }
        //public ICollection<Message>? Messages { get; set; }
        //public Transaction? Transaction { get; set; }
        public int? StatusId { get; set; } = 1;
        [ForeignKey("StatusId")]
        public virtual Status? Status { get; set; }
    }
}
