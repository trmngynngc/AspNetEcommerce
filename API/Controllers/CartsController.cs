using Application.Cart.CartDetails;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CartsController : ApiController
{
    [HttpGet("Details")]
    public async Task<ActionResult<ListCartDetailResponseDTO>> GetCartDetails([FromQuery] ListCartDetailRequestDTO pagingParams)
    {
        return HandleResult(await Mediator.Send(new List.Query { QueryParams = pagingParams }));
    }
    [HttpPost("Details")]
    public async Task<IActionResult> CreateCartDetail(CreateCartDetailRequestDTO cartDetail)
    {
        return HandleResult(await Mediator.Send(new Create.Command { CartDetails = cartDetail }));
    }
    [HttpPut("Details")]
    public async Task<IActionResult> Edit(EditCartDetailRequestDTO cartDetail)
    {
        return HandleResult(await Mediator.Send(new Edit.Command { CartDetails = cartDetail }));
    }

    [HttpDelete("Details")]
    public async Task<IActionResult> DeleteCartDetail(string cartId, Guid productId)
    {
        return HandleResult(await Mediator.Send((new Delete.Command { CartId = cartId, ProductId = productId})));
    }
}
