using Application.Core;
using Domain.Product;
using MediatR;
using Persistence;

namespace Application.Products;

public class Details
{
    public class Query : IRequest<Result<GetProductResponseDTO>>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<GetProductResponseDTO>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<GetProductResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            return Result<GetProductResponseDTO>.Success(new GetProductResponseDTO { Product = await _context.Products.FindAsync(request.Id) });
        }
    }
}