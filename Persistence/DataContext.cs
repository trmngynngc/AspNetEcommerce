using Domain;
using Domain.Cart;
using Domain.Product;
using Domain.Product.Category;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<UserCoupon> UserCoupons { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartDetail> CartDetails { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<UserCoupon>(entity => entity.HasKey(
            userCoupon => new { userCoupon.UserId, userCoupon.CouponId }));

        builder.Entity<CartDetail>(entity => entity.HasKey(
            cartDetail => new { cartDetail.CartId, cartDetail.ProductId }));
    }
}
