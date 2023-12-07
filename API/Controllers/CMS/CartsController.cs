using Application.Cart.CartDetails;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.CMS;

public class CartsController : CmsApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateCartDetail(CreateCartDetailRequestDTO cartDetail)
    {
        return HandleResult(await Mediator.Send(new Create.Command { CartDetails = cartDetail }));
    }

    [HttpDelete("users")]
    public async Task<IActionResult> DeleteCartDetail(Guid cartId, Guid productId)
    {
        return HandleResult(await Mediator.Send((new Delete.Command { CartId = cartId, ProductId = productId})));
    }
}
