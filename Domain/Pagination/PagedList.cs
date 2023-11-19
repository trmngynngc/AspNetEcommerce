using Microsoft.EntityFrameworkCore;

namespace Domain.Pagination;

public class PagedList<T>
{
    public PagedList(IQueryable<T> source, int pageNumber, int pageSize)
    {
        Items = new List<T>(GetItems(source, pageNumber, pageSize));
        var count = Items.Count;
        Pagination = new Pagination(pageNumber, (int)Math.Ceiling(count / (double)pageSize), pageSize, count);
    }

    private ICollection<T> GetItems(IQueryable<T> source, int pageNumber, int pageSize)
    {
        return source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }

    public ICollection<T> Items { get; set; }
    public Pagination Pagination { get; set; }
}