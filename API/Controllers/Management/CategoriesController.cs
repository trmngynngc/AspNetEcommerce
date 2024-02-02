using Application.Categories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers.Management;

public class CategoriesController: ManagementApiController
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create a Category")]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequestDTO category)
    {
        return HandleResult(await Mediator.Send(new Create.Command { Category = category }));
    }
    
    [HttpPut]
    [SwaggerOperation(Summary = "Edit a Category")]
    public async Task<IActionResult> EditCategory(EditCategoryRequestDTO category)
    {
        return HandleResult(await Mediator.Send(new Edit.Command { Category = category }));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a Category")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
    }
}
