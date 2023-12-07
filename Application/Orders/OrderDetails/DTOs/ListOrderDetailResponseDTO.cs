using Application.Core;
using Domain;
using Domain.OrderDetail;

namespace Application.Order.OrderDetails;

public class ListOrderDetailResponseDTO
{
    public List<OrderDetail> ListOrderDetails { get; set; }
}
