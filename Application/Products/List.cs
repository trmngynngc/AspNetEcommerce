using Application.Core;
using Domain.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products;

public class List
{
   public class Query : IRequest<List<MockProduct>>
   {
      public PagingParams QueryParams { get; set; }
   }
   
   public class Handler : IRequestHandler<Query, List<MockProduct>>
   {
      private readonly DataContext _context;

      public Handler(DataContext context)
      {
         _context = context;
      }

      public async Task<List<MockProduct>> Handle(Query request, CancellationToken cancellationToken)
      {
        var products = await _context.Products.ToListAsync();

        return products;
      }
   }
}