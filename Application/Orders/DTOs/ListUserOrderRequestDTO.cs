using Application.Core;

namespace Application.Orders;

public class ListUserOrderRequestDTO : PagingParams
{
    public string UserId { get; set; }
}