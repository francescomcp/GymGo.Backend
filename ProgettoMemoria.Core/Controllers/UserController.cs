using GymGo.Core.Services;
using Microsoft.AspNetCore.Mvc;
using GymGo.Gateway.Models.User;
using GymGo.Core.Helpers;

namespace GymGo.Core.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest model)
    {
        var response = await _service.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Save(PostUserRequest user)
    {
        await _service.Save(user);
        return NoContent();
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
    public async Task<IActionResult> GetById(string Id)
    {
        var result = await _service.GetById(Id);
        return result is not null
            ? Ok(result)
            : NotFound();
    }
}
