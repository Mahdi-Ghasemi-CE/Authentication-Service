using Application.Services.Authentication;
using Authentication_Service.Application.Services.User;
using Authentication_Service.Extensions;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AccountController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var response  = await _authenticationService.Login(request);
        return this.ReturnResponse(response);
    }
}