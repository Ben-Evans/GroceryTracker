namespace Web.Extensions;

public static class StartupExtensions
{
    public static void MapApiControllers(this WebApplication app)
    {
        app.MapGet("/", () => "Hello World");
        app.MapGet("/weather", () => new { Weather = "Rainy" });
    }
}
