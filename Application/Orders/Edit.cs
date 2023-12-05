using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Orders;

public class Edit
{
    public class Command : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
        public EditOrderRequestDTO Order { get; set; }
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
            var order = await _context.Orders.FindAsync(request.Id);

            if (order == null)
            {
                return null;
            }

            _mapper.Map(request.Order, order);

            await _context.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
