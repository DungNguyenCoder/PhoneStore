using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SellPhoneWebsite.Models.Entities;

namespace SellPhoneWebsite.Data
{
    public class ApplicationDbContext :
        IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<CartItem> CartItem { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // =============================
            // Composite Keys
            // =============================
            builder.Entity<OrderItem>()
                .HasKey(o => new { o.ProductID, o.OrderID });

            builder.Entity<CartItem>()
                .HasKey(c => new { c.UserID, c.ProductID });

            // =============================
            // Decimal Precision
            // =============================
            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(12, 2);

            builder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasPrecision(12, 2);

            builder.Entity<OrderItem>()
                .Property(o => o.SoldPrice)
                .HasPrecision(12, 2);

            // =============================
            // Relationships
            // =============================

            // Category - Product (1-n)
            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            // ProductImage - Product (1-n)
            builder.Entity<ProductImage>()
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(p => p.ProductID);

            // Order - User (n-1)
            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserID);

            // OrderItem
            builder.Entity<OrderItem>()
                .HasOne(o => o.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(o => o.ProductID);

            builder.Entity<OrderItem>()
                .HasOne(o => o.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(o => o.OrderID);

            // CartItem
            builder.Entity<CartItem>()
                .HasOne(c => c.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(c => c.ProductID);

            builder.Entity<CartItem>()
                .HasOne(c => c.User)
                .WithMany(u => u.CartItems)
                .HasForeignKey(c => c.UserID);
        }
    }
}
