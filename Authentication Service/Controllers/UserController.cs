namespace Authentication_Service.Controllers;

using Authentication_Service.Application.Services.User;
using Authentication_Service.Extensions;
using Domain.Users;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("AddStudent")]
    public async Task<IActionResult> AddStudent([FromBody] User request)
    {
        return this.ReturnResponse(null);
    }
}