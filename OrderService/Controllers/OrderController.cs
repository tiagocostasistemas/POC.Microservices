using Microsoft.AspNetCore.Mvc;
using OrderService.Application;
using OrderService.DTOs.Requests;

namespace OrderService.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderApplicationService _orderService;

    public OrderController(IOrderApplicationService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _orderService.GetAll();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var response = await _orderService.GetById(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] InsertOrderRequest request)
    {
        var response = await _orderService.Insert(request);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateOrderRequest request)
    {
        var response = await _orderService.Update(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _orderService.Delete(id);
        return Ok();
    }
}
