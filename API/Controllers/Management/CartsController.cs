using Application.Cart.CartDetails;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Management;

public class CartsController : ManagementApiController
{
    [HttpPost("Details")]
    public async Task<IActionResult> CreateCartDetail(CreateCartDetailRequestDTO cartDetail)
    {
        return HandleResult(await Mediator.Send(new Create.Command { CartDetails = cartDetail }));
    }

    [HttpDelete("Details")]
    public async Task<IActionResult> DeleteCartDetail(string cartId, Guid productId)
    {
        return HandleResult(await Mediator.Send((new Delete.Command { CartId = cartId, ProductId = productId})));
    }
}
