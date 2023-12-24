using Application.Core;
using Application.Products;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductsController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<ListProductResponseDTO>> GetProducts([FromQuery] PagingParams pagingParams)
    {
        return HandleResult(await Mediator.Send(new List.Query{QueryParams = pagingParams}));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetProductResponseDTO>> GetProduct(Guid id)
    {
        return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
    }


} 