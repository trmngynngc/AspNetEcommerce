using Application.Cart.CartDetails;
using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CartsController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> GetCartDetails([FromQuery] PagingParams pagingParams)
    {
        return HandleResult(await Mediator.Send(new List.Query { QueryParams = pagingParams }));
    }
}
