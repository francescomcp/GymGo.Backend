using ProgettoPromemoria.Gateway.Models.Memo;
using ProgettoPromemoria.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProgettoPromemoria.Controllers;

[ApiController]
[Route("[controller]")]
public class MemoController : ControllerBase
{
    public IMemoService _service;

    public MemoController(IMemoService service)
    {
        _service = service;
    }

    [HttpGet("health")]
    public string HealthCheck()
    {
        return "Hello";
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var list = await _service.GetAll();
        return list is not null 
            ? Ok(list) 
            : NotFound();
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _service.GetById(id);
        return result is not null
            ? Ok(result)
            : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Save(PostMemoRequest memo)
    {
        await _service.Save(memo);
        return NoContent();
    }
}
