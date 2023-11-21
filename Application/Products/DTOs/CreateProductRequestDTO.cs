using System.ComponentModel.DataAnnotations;
using Domain.Product.Category;

namespace Application.Products;

public class CreateProductRequestDTO
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public string Thumbnail { get; set; }
    public string? Description { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be not be negative")]
    public int Stocks { get; set; }

    public Guid CategoryId { get; set; }
}
