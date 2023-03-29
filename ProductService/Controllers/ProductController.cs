using Microsoft.AspNetCore.Mvc;
using ProductService.Application;
using ProductService.DTOs.Requests;

namespace ProductService.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductApplicationService _productService;

    public ProductController(IProductApplicationService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _productService.GetAll();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var response = await _productService.GetById(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] InsertProductRequest request)
    {
        var response = await _productService.Insert(request);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateProductRequest request)
    {
        var response = await _productService.Update(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _productService.Delete(id);
        return Ok();
    }
}
