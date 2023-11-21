using Application.Core;
using Domain.Product.Category;
namespace Application.Categories;

public class ListCategoryResponseDTO
{
    public ICollection<Category> Categories { get; set; }
}
