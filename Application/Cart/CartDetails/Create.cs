using Application.Core;
using AutoMapper;
using Domain;
using Domain.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Cart.CartDetails;

public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public CreateCartDetailRequestDTO CartDetails { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var item = await _context.CartDetails.FirstOrDefaultAsync(
                entity => entity.CartId == request.CartDetails.CartId
                          && entity.ProductId == request.CartDetails.ProductId
            );

            if (item == null)
            {
                _context.Add(request.CartDetails);
            }
            else
                item.Quantity += request.CartDetails.Quantity;

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
