using Microsoft.EntityFrameworkCore;

namespace Application.Core;

public class PagedList<T>
{
    public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
    {
        Pagination = new Pagination(pageNumber, (int)Math.Ceiling(count / (double)pageSize), pageSize, count);
        Items = new List<T>(items);
    }

    public ICollection<T> Items { get; set; }
    public Pagination Pagination { get; set; }

    public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedList<T>(items, items.Count, pageNumber, pageSize);
    }
}