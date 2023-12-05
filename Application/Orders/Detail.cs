using Application.Core;
using MediatR;
using Persistence;

namespace Application.Orders;

public class Details
{
    public class Query : IRequest<Result<GetOrderResponseDTO>>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<GetOrderResponseDTO>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<GetOrderResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FindAsync(request.Id);

            if (order == null)
            {
                return null;
            }

            return Result<GetOrderResponseDTO>.Success(new GetOrderResponseDTO { Order = order });
        }
    }
}
