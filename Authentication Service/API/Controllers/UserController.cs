using Authentication_Service.API.Extensions;
using Authentication_Service.Application.Interfaces.Services;
using Authentication_Service.Domain.Users;
namespace Authentication_Service.API.Controllers;

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