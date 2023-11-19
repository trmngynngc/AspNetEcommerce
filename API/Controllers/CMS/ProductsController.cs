using Application.Products;
using Domain.Product;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.CMS;

public class ProductsController : CmsApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductRequestDTO product)
    {
        return HandleResult(await Mediator.Send(new Create.Command { Product =  product}));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditProduct(Guid id, EditProductRequestDTO product)
    {
        return HandleResult(await Mediator.Send(new Edit.Command { Id = id, Product = product }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        return HandleResult(await Mediator.Send((new Delete.Command { Id = id })));
    }
}