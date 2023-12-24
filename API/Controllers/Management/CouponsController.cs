using Application.Core;
using Application.Coupons;
using Application.Coupons.UserCoupons;
using Microsoft.AspNetCore.Mvc;
using Create = Application.Coupons.Create;
using CreateUserCoupon = Application.Coupons.UserCoupons.Create;
using Delete = Application.Coupons.Delete;
using DeleteUserCoupon = Application.Coupons.UserCoupons.Delete;
using List = Application.Coupons.List;
using ListUserCoupon = Application.Coupons.UserCoupons.List;

namespace API.Controllers.Management;

public class CouponsController : ManagementApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateCoupon(CreateCouponRequestDTO coupon)
    {
        return HandleResult(await Mediator.Send(new Create.Command { Coupon = coupon }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditCoupon(Guid id, EditCouponRequestDTO coupon)
    {
        return HandleResult(await Mediator.Send(new Edit.Command { Id = id, Coupon = coupon }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCoupon(Guid id)
    {
        return HandleResult(await Mediator.Send((new Delete.Command { Id = id })));
    }

    [HttpGet]
    public async Task<ActionResult<ListCouponResponseDTO>> GetCoupons([FromQuery] PagingParams pagingParams)
    {
        return HandleResult(await Mediator.Send(new List.Query { QueryParams = pagingParams }));
    }

    [HttpPost("users")]
    public async Task<IActionResult> CreateUserCoupon(CreateUserCouponRequestDTO userCoupon)
    {
        return HandleResult(await Mediator.Send(new CreateUserCoupon.Command { UserCoupon = userCoupon }));
    }

    [HttpDelete("users")]
    public async Task<IActionResult> DeleteUserCoupon(Guid couponId, Guid userId)
    {
        return HandleResult(await Mediator.Send((new DeleteUserCoupon.Command { CouponId = couponId, UserId = userId})));
    }

    [HttpGet("users")]
    public async Task<ActionResult<ListUserCouponResponseDTO>> GetUserCoupons([FromQuery] PagingParams pagingParams)
    {
        return HandleResult(await Mediator.Send(new ListUserCoupon.Query { QueryParams = pagingParams }));
    }
}
