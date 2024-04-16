namespace Authentication_Service.Controllers;

using Authentication_Service.Application.Services.User;
using Authentication_Service.Extensions;
using Authentication_Service.Extensions.Attributes;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[JwtAuthorize("User")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;

    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] UserRequest request)
    {
        var response = await _userService.Add(request);
        return this.ReturnResponse(response);
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _userService.Get(id);
        return this.ReturnResponse(response);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] UserRequest request)
    {
        var response = await _userService.Update(request);
        return this.ReturnResponse(response);
    }

    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        var response = await _userService.Remove(id);
        return this.ReturnResponse(response);
    }
}