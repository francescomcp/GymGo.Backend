using ProgettoPromemoria.Core.Services;
using Microsoft.AspNetCore.Mvc;
using ProgettoPromemoria.Gateway.Models.User;

namespace ProgettoPromemoria.Core.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
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
    public async Task<IActionResult> GetById(string Id)
    {
        var result = await _service.GetById(Id);
        return result is not null
            ? Ok(result)
            : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Save(PostUserRequest user)
    {
        await _service.Save(user);
        return NoContent();
    }
}
