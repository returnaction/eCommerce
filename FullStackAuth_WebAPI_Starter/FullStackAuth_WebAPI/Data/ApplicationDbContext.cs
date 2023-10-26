using FullStackAuth_WebAPI.Configuration;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FullStackAuth_WebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProfileImage> ProfileImages { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewImage> ReviewImages { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions options)
    : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RolesConfiguration());

            modelBuilder.Entity<Purchase>()
                    .HasOne(m => m.BuyerUser)
                    .WithMany(t => t.PurchasesUserISBuyer)
                    .HasForeignKey(m => m.BuyerUserId);


            modelBuilder.Entity<Purchase>()
                        .HasOne(m => m.SellerUser)
                        .WithMany(t => t.PurchasesUserIsSeller)
                        .HasForeignKey(m => m.SellerUserId);

            modelBuilder.Entity<Purchase>()
                        .HasOne(m => m.ReviewOfPurchase)
                        .WithOne(t => t.PurchaseOfProductReview)
                        .HasForeignKey<Review>(m => m.ReviewId);
        }
    }
}
