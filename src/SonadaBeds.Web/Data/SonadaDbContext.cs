using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SonadaBeds.Web.Models;
namespace SonadaBeds.Web.Data;
public class SonadaDbContext(DbContextOptions<SonadaDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
 public DbSet<Category> Categories => Set<Category>(); public DbSet<Product> Products => Set<Product>(); public DbSet<ProductOption> ProductOptions => Set<ProductOption>(); public DbSet<Order> Orders => Set<Order>(); public DbSet<OrderItem> OrderItems => Set<OrderItem>(); public DbSet<ProductReview> Reviews => Set<ProductReview>(); public DbSet<Coupon> Coupons => Set<Coupon>(); public DbSet<NewsletterSubscriber> NewsletterSubscribers => Set<NewsletterSubscriber>(); public DbSet<SwatchRequest> SwatchRequests => Set<SwatchRequest>(); public DbSet<PostcodeRule> PostcodeRules => Set<PostcodeRule>(); public DbSet<CmsPage> CmsPages => Set<CmsPage>(); public DbSet<Faq> Faqs => Set<Faq>();
 protected override void OnModelCreating(ModelBuilder b){base.OnModelCreating(b); b.Entity<Product>().HasIndex(x=>x.Slug).IsUnique(); b.Entity<Category>().HasIndex(x=>x.Slug).IsUnique(); b.Entity<Order>().HasIndex(x=>x.OrderNumber).IsUnique(); b.Entity<Coupon>().HasIndex(x=>x.Code).IsUnique(); b.Entity<Product>().Property(x=>x.BasePrice).HasPrecision(18,2); b.Entity<ProductOption>().Property(x=>x.PriceAdjustment).HasPrecision(18,2); b.Entity<Order>().Property(x=>x.Total).HasPrecision(18,2); b.Entity<Order>().Property(x=>x.Subtotal).HasPrecision(18,2); }
}
