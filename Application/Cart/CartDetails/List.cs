﻿using Application.Core;
using MediatR;
using Persistence;

namespace Application.Cart.CartDetails;

public class List
{
    public class Query : IRequest<Result<ListCartDetailResponseDTO>>
    {
        public ListCartDetailRequestDTO QueryParams { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<ListCartDetailResponseDTO>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<ListCartDetailResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = _context.CartDetails
                .Where(cartDetail => cartDetail.CartId == request.QueryParams.CartId)
                .AsQueryable();

            var cartItem = new ListCartDetailResponseDTO();
            await cartItem.GetItemsAsync(query, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return Result<ListCartDetailResponseDTO>.Success(cartItem);
        }
    }
}
