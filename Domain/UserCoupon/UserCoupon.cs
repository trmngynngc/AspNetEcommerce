namespace Domain;

public class UserCoupon
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid CouponId { get; set; }
    public Coupon Coupon { get; set; }
}
