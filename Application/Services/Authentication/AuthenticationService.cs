using Application.Services.Authentication;
using Authentication_Service.Application.Services.User;
using Authentication_Service.Application.Utils;
using Domain.Entities.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using Options = Authentication_Service.Application.Utils.Options;

namespace Authentication_Service.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly Options _options;
    private readonly IUserService _userService;

    public AuthenticationService(IOptions<Options> options, IUserService userService)
    {
        _options = options.Value;
        _userService = userService;
    }

    public string GenerateToken(List<Claim> claims, int tokenDuration)
    {
        var key = new SymmetricSecurityKey(
            System.Text
            .Encoding.UTF8
            .GetBytes(_options.SecretKey));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(tokenDuration),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    public List<Claim> GetClaims(Domain.Entities.Users.User user,int tokenDuration)
    {
        List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                    new Claim(ClaimTypes.MobilePhone, user.Mobile),
                    new Claim(ClaimTypes.Role, user.Role.SystemName),
                    new Claim(ClaimTypes.Expiration, DateTime.Now.AddMinutes(tokenDuration).ToString())
                };

        return claims;
    }

    public async Task<OperationResult> Login(LoginRequest request)
    {
        var user = await _userService.GetByMobile(request.Mobile);
        try
        {
            // access token
            var accessClaims = GetClaims((Domain.Entities.Users.User)user.Value, _options.AccessTokenDuration);
            var accessToken = GenerateToken(accessClaims, _options.AccessTokenDuration);          
            
            // refresh token
            var refreshClaims = GetClaims((Domain.Entities.Users.User)user.Value, _options.RefreshTokenDuration);
            var refreshToken = GenerateToken(accessClaims, _options.RefreshTokenDuration);


            var loginResponse = new LoginResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };

            return new OperationResult(HttpStatusCode.BadRequest, loginResponse);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return new OperationResult(HttpStatusCode.BadRequest, ex);
        }
    }
}