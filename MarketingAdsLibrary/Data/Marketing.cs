using MarketingAds.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MarketingAds.Data
{
    public class Marketing: DbContext
    {
        private readonly IConfiguration _configuration;

        public Marketing(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("DbConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Location> Locations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.MessagesSent)
                .WithOne(m => m.Sender)
                .HasForeignKey(m => m.SenderID)
                .OnDelete(DeleteBehavior.Restrict); // Example: No cascade delete on MessagesSent

            modelBuilder.Entity<User>()
                .HasMany(u => u.MessagesReceived)
                .WithOne(m => m.Receiver)
                .HasForeignKey(m => m.ReceiverID)
                .OnDelete(DeleteBehavior.Restrict); // Example: No cascade delete on MessagesReceived

            

            //modelBuilder.Entity<Listing>()
            //    .HasOne(l => l.Transaction)
            //    .WithOne(t => t.Listing)
            //    .HasForeignKey<Transaction>(t => t.ListingID)
            //    .OnDelete(DeleteBehavior.Restrict); // Example: No cascade delete on Transaction

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Buyer)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.BuyerID)
                .OnDelete(DeleteBehavior.Restrict); // Example: No cascade delete on Transactions

            modelBuilder.Entity<Listing>()
                .HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserID)
                .OnDelete(DeleteBehavior.Restrict); // Example: No cascade delete on User

            modelBuilder.Entity<Listing>()
                .HasOne(l => l.Category)
                .WithMany()
                .HasForeignKey(l => l.CategoryID)
                .OnDelete(DeleteBehavior.Restrict); // Example: No cascade delete on Category
            modelBuilder.Entity<Listing>()
               .HasOne(l => l.Location)
               .WithMany()
               .HasForeignKey(l => l.LocationID)
               .OnDelete(DeleteBehavior.Restrict); // Example: No cascade delete on Category

            base.OnModelCreating(modelBuilder);
        }

    }

}

