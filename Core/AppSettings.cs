using Microsoft.Extensions.Configuration;

namespace Core;

public interface IAppSettings
{
}

public class AppSettings : IAppSettings
{
    private readonly IConfiguration _config;

    public AppSettings(IConfiguration config)
    {
        _config = config;
    }

    public string ConnectionString => _config["ConnectionStrings:DefaultConnection"];
}
