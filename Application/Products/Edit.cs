using Application.Core;
using Domain.Product;
using MediatR;
using Persistence;

namespace Application.Products;

public class Edit
{
    public class Command : IRequest<Result<Unit>>
    {
        public MockProduct MockProduct { get; set; }
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
            var mockproduct = await _context.Products.FindAsync(request.MockProduct.Id);
            
            return Result<Unit>.Success(Unit.Value);
        }
    }
}