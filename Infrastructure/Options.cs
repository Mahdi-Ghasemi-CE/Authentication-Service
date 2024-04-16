namespace Authentication_Service.Application.Utils;

public class Options
{
    public string DbConnection { get; set; }
    public string SecretKey { get; set; }
    public int AccessTokenDuration { get; set; }
    public int RefreshTokenDuration { get; set; }
}