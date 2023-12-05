﻿using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Orders;

public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public CreateOrderRequestDTO Order { get; set; }
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
            var order = new Order();
            _mapper.Map(request.Order, order);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}