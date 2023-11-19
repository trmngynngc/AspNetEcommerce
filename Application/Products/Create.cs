using Application.Core;
using Domain.Product;
using MediatR;
using Persistence;

namespace Application.Products;

public class Create
{
   public class Command : IRequest<Result<Unit>>
   {
      public Product Product { get; set; }
   }

   public class Handler : IRequestHandler<Command, Result<Unit>>
   {
      private readonly DataContext _context;
      
      public Handler(DataContext context)
      {
         _context = context;
      }

      public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
         _context.Products.Add(request.Product);
         await _context.SaveChangesAsync();

         return Result<Unit>.Success(Unit.Value);
      }
   }
}