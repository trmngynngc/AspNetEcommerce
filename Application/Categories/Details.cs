using Application.Core;
using Domain.Product;
using MediatR;
using Persistence;

namespace Application.Categories;

public class Details
{
    public class Query : IRequest<Result<GetCategoryResponseDTO>>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<GetCategoryResponseDTO>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<GetCategoryResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            return Result<GetCategoryResponseDTO>.Success(new GetCategoryResponseDTO(){ Category = await _context.Categories.FindAsync(request.Id) });
        }
    }
}
