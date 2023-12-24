using Application.Categories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Management;

public class CategoriesController: ManagementApiController
{
    [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDTO category)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Category = category}));
        }

    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
}
