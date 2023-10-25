using Application.Core;
using Domain.Product;
using MediatR;
using Persistence;

namespace Application.Products;

public class Create
{
   public class Command : IRequest<Unit>
   {
      public MockProduct MockProduct { get; set; }
   }

   public class Handler : IRequestHandler<Command>
   {
      private readonly DataContext _context;
      
      public Handler(DataContext context)
      {
         _context = context;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
         _context.Products.Add(request.MockProduct);
         await _context.SaveChangesAsync();

         return Unit.Value;
      }
   }
}