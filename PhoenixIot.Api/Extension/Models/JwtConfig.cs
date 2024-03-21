namespace PhoenixIot.Extension.Models;

public class JwtConfig
{
    public string Secret { get; set; } = null!;
    public string EncryptionKey { get; set; } = null!;
}