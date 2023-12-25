using System.ComponentModel.DataAnnotations;

namespace Application.Cart.CartDetails;

public class EditCartDetailRequestDTO
{
    public string CartId { get; set; }
    public Guid ProductId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be > 0")]
    public int Quantity { get; set; }
}
