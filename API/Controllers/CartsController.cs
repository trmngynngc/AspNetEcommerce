using Application.Cart.CartDetails;
using Application.Core;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CartsController : ApiController
{
    [HttpGet("Details")]
    public async Task<ActionResult<ListCartDetailResponseDTO>> GetCartDetails([FromQuery] PagingParams pagingParams)
    {
        return HandleResult(await Mediator.Send(new List.Query { QueryParams = pagingParams }));
    }
}
