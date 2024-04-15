namespace Authentication_Service.Application.Utils;
using System.Net;

public class OperationResult
{
    public readonly HttpStatusCode Status;
    public readonly object Value;

    public OperationResult(HttpStatusCode status, object value)
    {
        Status = status;
        Value = value;
    }

    public bool Succeeded => IsSucceeded(Status);

    private bool IsSucceeded(HttpStatusCode status) => status switch
    {
        _ when
            status == HttpStatusCode.OK => true,
        _ when
            status == HttpStatusCode.NotAcceptable ||
            status == HttpStatusCode.NotFound => false,
        _ => false
    };

    public OperationResult Clone() => (OperationResult)MemberwiseClone();
}