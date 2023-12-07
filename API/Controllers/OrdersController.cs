using Application.Core;
using Application.Orders;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class OrdersController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderRequestDTO order)
    {
        return HandleResult(await Mediator.Send(new Create.Command { OrderDto = order }));

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditOrder(Guid id, EditOrderRequestDTO order)
    {
        return HandleResult(await Mediator.Send(new Edit.Command { Id = id, Order = order }));
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] PagingParams pagingParams)
    {
        return HandleResult(await Mediator.Send(new List.Query { QueryParams = pagingParams }));
    }
}
