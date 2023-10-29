using Application.Core;
using Domain.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products;

public class Details
{
   public class Query : IRequest<MockProduct>
   {
      public Guid Id { get; set; }
   } 
   
   public class Handler : IRequestHandler<Query, MockProduct>
   {
      private readonly DataContext _context;

      public Handler(DataContext context)
      {
         _context = context;
      }

      public async Task<MockProduct> Handle(Query request, CancellationToken cancellationToken)
      {
         return await _context.Products.FindAsync(request.Id);
      }
   }
}