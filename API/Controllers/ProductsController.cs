using Application.Products;
using Domain.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductsController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] PagingParams pagingParams)
    {
        return HandleResult(await Mediator.Send(new List.Query{QueryParams = pagingParams}));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
    }


} 