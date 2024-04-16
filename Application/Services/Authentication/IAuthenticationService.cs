using Authentication_Service.Application.Utils;
using Azure;
using Domain.Entities.Users;
using System.Security.Claims;

namespace Application.Services.Authentication;

public interface IAuthenticationService
{
    Task<OperationResult> Login(LoginRequest user);
    List<Claim> GetClaims(User user, int tokenDuration);
    string GenerateToken(List<Claim> claims, int tokenDuration);

    /*Task<OperationResult<bool>> SetRefreshToken(UserEntryModel user, string refreshToken);
    Task<OperationResult<string>> GenerateRefreshToken(UserEntryModel user);
    Task<OperationResult<List<Claim>>> GetRefreshClaims(string mobile);
    Task<OperationResult<LoginResponseModel>> CreateNewAccessToken(string refreshToken);
    Task<OperationResult<int>> GetUserIdByToken(string AccessToken);
    Task<OperationResult<bool>> UserActivation(ActivationUserEntryModel model);
    Task<OperationResult<bool>> IsValidVerifyCode(string mobile, string verifyCode);
    Task<OperationResult<bool>> GeneratingNewVerifyCode(string mobile);
    Task<OperationResult<bool>> ActivationUser(UserEntryModel user);
    Task<OperationResult<bool>> ForgetPassword(string mobile);*/
}
