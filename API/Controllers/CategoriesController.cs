using Application.Categories;
using Application.Core;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CategoriesController: ApiController
{
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        return HandleResult(await Mediator.Send(new List.Query()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(Guid id)
    {
        return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
    }


}
