using Application.Core;
using Domain.Product;
using MediatR;
using Persistence;

namespace Application.Products;

public class Details
{
   public class Query : IRequest<Result<MockProduct>>
   {
      public Guid Id { get; set; }
   } 
   
   public class Handler : IRequestHandler<Query, Result<MockProduct>>
   {
      private readonly DataContext _context;

      public Handler(DataContext context)
      {
         _context = context;
      }

      public async Task<Result<MockProduct>> Handle(Query request, CancellationToken cancellationToken)
      {
         throw new NotImplementedException();
      }
   }
}