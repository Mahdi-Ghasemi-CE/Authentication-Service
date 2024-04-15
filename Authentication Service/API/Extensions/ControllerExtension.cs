using System.Net;
using Authentication_Service.Application.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_Service.API.Extensions;

public static class ControllerExtension
{
    public static IActionResult ReturnResponse(this ControllerBase controller, OperationResult operation)
    {
        object response = operation.Value;

        return operation.Status switch
        {
            HttpStatusCode.OK => controller.Ok(response),
            HttpStatusCode.NotAcceptable => controller.BadRequest(response),
            HttpStatusCode.NotFound => controller.NotFound(response),
            _ => controller.UnprocessableEntity(response)
        };
    }
}