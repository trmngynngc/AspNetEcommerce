using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Cart.CartDetails;

public class Delete
{
    public class Command : IRequest<Result<Unit>>
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
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
            var cartDetail = await _context.CartDetails.FindAsync(request.CartId, request.ProductId);

            if (cartDetail == null)
            {
                return null;
            }

            _context.Remove(cartDetail);
            await _context.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
