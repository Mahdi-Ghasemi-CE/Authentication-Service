using Azure;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace Authentication_Service.Extensions.Attributes
{
    public class JwtAuthorizeAttribute : System.Attribute, IAuthorizationFilter
    {
        #region Constructor

        public string Role { get; set; }

        public string[]? Roles { get; set; }

        private string? accessToken;

        public JwtAuthorizeAttribute(string Role)
        {
            this.Role = Role;
            SplitRoles();
        }

        #endregion

        #region OnAuthorization

        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                string authorizationValue = context.HttpContext!.Request.Headers["Authorization"];
                accessToken = authorizationValue.Substring(7);

                //validation of access token time
                if (await IsAccessTokenValid())
                {
                    //If user role is equal with attribute role go to next conditions
                    if (!await IsValidRole())
                    {
                        context.Result = new JsonResult(new { Message = "شما به این بخش دسترسی ندارید." })
                        {
                            StatusCode = StatusCodes.Status405MethodNotAllowed
                        };
                    }
                }
                else
                {
                    //validation of refresh access token time
                    if (await IsValidRefreshToken())
                    {
                        context.Result = new JsonResult(new { Message = "Forbidden" })
                        {
                            StatusCode = StatusCodes.Status403Forbidden
                        };
                    }
                    else
                    {
                        context.Result = new JsonResult(new { Message = "Unauthorized" })
                        {
                            StatusCode = StatusCodes.Status401Unauthorized
                        };
                    }
                }
            }
            catch
            {
                context.Result = new JsonResult(new { Message = "Unauthorization" })
                { 
                    StatusCode = StatusCodes.Status401Unauthorized 
                };
            }

            // The token is valid and user has access.
        }

        #endregion

        #region IsAccessTokenValid

        public async Task<bool> IsAccessTokenValid()
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(accessToken);
            var exp = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Expiration);
            var validTo = DateTime.Parse(exp.Value);
            return (DateTime.Now <= validTo);
        }

        #endregion

        #region IsRefreshTokenValid

        public async Task<bool> IsValidRefreshToken()
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(accessToken);
            var exp = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Expiration);
            var validTo = DateTime.Parse(exp.Value);
            return (DateTime.Now <= validTo);
        }

        #endregion

        #region GetUserRole

        public async Task<string> GetUserRole()
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(accessToken);
            var role = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;

            return role;
        }

        #endregion

        #region SetSplitRoles

        public void SplitRoles()
        {
            this.Roles = this.Role.Split(',');
        }

        #endregion

        #region IsValidRole

        public async Task<bool> IsValidRole()
        {
            var userRole = await GetUserRole();
            return this.Roles.Contains(userRole);
        }

        #endregion
    }
}