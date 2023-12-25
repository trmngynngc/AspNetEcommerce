using Application.Core;

namespace Application.Cart.CartDetails;

public class ListCartDetailRequestDTO : PagingParams
{
    public string CartId { get; set; }
}