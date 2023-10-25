using Application.Core;
using Application.Products;
using Domain.Product;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace API.Controllers;

public class ProductsController : BaseApiController
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<List<MockProduct>> GetProducts()
    {
        return await _mediator.Send(new List.Query());
    }

    [HttpGet("{id}")]
    public async Task<Result<MockProduct>> GetMockProduct(Guid id)
    {
        return await Mediator.Send(new Details.Query{Id = id});
    }

    [HttpPost]
    public async Task<IActionResult> CreateMockProduct(MockProduct mockProduct)
    {
        await Mediator.Send(new Create.Command { MockProduct = mockProduct });
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditMockProduct(Guid id, MockProduct mockProduct)
    {
        mockProduct.Id = id;
        await Mediator.Send(new Edit.Command { MockProduct = mockProduct });

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMockProduct(Guid id)
    {
        await Mediator.Send((new Delete.Command { Id = id }));
        
        return Ok();
    }
    
    
    
    
} 