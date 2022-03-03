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

    [HttpGet]
    public string HealthCheck()
    {
        return "Hello";
    }

    [HttpPost]
    public async Task<IActionResult> Save(PostMemoRequest memo)
    {
        await _service.Save(memo);
        return Ok(memo);
    }
}
