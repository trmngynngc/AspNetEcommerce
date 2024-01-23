using Application.Order.OrderDetails;
using Application.Orders;
using Microsoft.AspNetCore.Mvc;
using List = Application.Orders.OrderDetails.List;

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
    public async Task<ActionResult<ListOrderResponseDTO>> GetOrders([FromQuery] ListUserOrderRequestDTO pagingParams)
    {
        return HandleResult(await Mediator.Send(new ListUserOrder.Query { QueryParams = pagingParams }));
    }
    
    [HttpGet("{id}/Details")]
    public async Task<ActionResult<ListOrderDetailResponseDTO>> GetOrderDetails(Guid orderId)
    {
        return HandleResult(await Mediator.Send(new List.Query { Id = orderId}));
    }
}
