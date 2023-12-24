using Application.Categories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CategoriesController: ApiController
{
    [HttpGet]
    public async Task<ActionResult<ListCategoryResponseDTO>> GetCategories()
    {
        return HandleResult(await Mediator.Send(new List.Query()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetCategoryResponseDTO>> GetCategory(Guid id)
    {
        return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
    }


}
