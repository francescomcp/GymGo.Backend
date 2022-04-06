using GymGo.Gateway.Models.Memo;
using GymGo.Core.Services;
using Microsoft.AspNetCore.Mvc;
using GymGo.Core.Helpers;

namespace GymGo.Controllers;

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

    [Authorize]
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var list = await _service.GetAll();
        return list is not null 
            ? Ok(list) 
            : NotFound();
    }

    [Authorize]
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _service.GetById(id);
        return result is not null
            ? Ok(result)
            : NotFound();   
    }
    
    [Authorize]
    [HttpGet("byUserDay")]
    public async Task<IActionResult> GetByUserDay(string id, int dayOfWeek)
    {
        var result = await _service.GetByUserDay(id, dayOfWeek);
        return result is not null
            ? Ok(result)
            : NotFound();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Save(PostMemoRequest memo)
    {
        await _service.Save(memo);
        return NoContent();
    }
}
