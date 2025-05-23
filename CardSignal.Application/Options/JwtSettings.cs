using CardSignal.Core.Enums;

namespace CardSignal.Application.Options;

public class JwtSettings
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Secret { get; set; }
    public TimeSpan LifeTime { get; set; }
}