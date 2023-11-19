using Domain.Pagination;

namespace Domain.Product;

public class ListProductResponseDTO : PagedList<Product>
{
    public ListProductResponseDTO(IQueryable<Product> source, int pageNumber, int pageSize) : base(source, pageNumber, pageSize)
    {
    }
}