using Application.Core;
using AutoMapper;
using Domain.Cart;
using MediatR;
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
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var item = await _context.CartDetails.FindAsync(request.CartDetails.CartId, request.CartDetails.ProductId);

            if (item == null)
            {
                item = new CartDetail();
                _mapper.Map(request.CartDetails, item);
                _context.Add(item);
            }
            else
            {
                item.Quantity += request.CartDetails.Quantity;
            }

            await _context.SaveChangesAsync();


            return Result<Unit>.Success(Unit.Value);
        }
    }
}