using DataAccess.Repositories;
using Microsoft.OpenApi.Models;

namespace Web.Extensions;

public static class StartupExtensions
{
    #region WebApplicationBuilder
    public static void AddAppSettings(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile("appsettings.json");
        builder.Services.AddScoped<IAppSettings, AppSettings>();
    }

    public static void AddSerilog(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .WriteTo.Console()
            .CreateLogger();

        builder.Logging.AddSerilog(Log.Logger);
    }

    public static void AddDbContext(this WebApplicationBuilder builder)
    {
        /* Package Manager Console
         * Add-Migration Migration_Name -Project DataAccess
         * Get-Migration
         * Remove-Migration
         * Reset All Migrations - Delete Migrations folder and drop DB
         * 
         * Update-Database
         */
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddSqlServer<ApplicationDbContext>(connectionString, x => x.MigrationsAssembly(nameof(DataAccess)));

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
    }

    public static void AddSwagger(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var baseExeDir = AppContext.BaseDirectory;
        var genDocPath = Path.Combine(baseExeDir, "SwaggerGenComments.xml");
        services.AddSwaggerGen(/*options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Nexus Api"
                    // Description = "" // TODO: Add app description
                });
                options.IncludeXmlComments(genDocPath);
            }*/);
    }

    public static void AddMappings(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddAutoMapper(typeof(Models.Mappings.MappingProfile));
    }

    public static void AddValidators(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddScoped<IFoodValidator, FoodValidator>();
    }

    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddScoped<IFoodInventoryRepository, FoodInventoryRepository>();
    }

    public static void AddCoreServices(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddScoped<IFoodInventoryService, FoodInventoryService>();
    }

    #endregion

    #region WebApplication
    public static void MapApiControllers(this WebApplication app)
    {
        app.MapGet("/", () => "Hello World");
        app.MapGet("/weather", () => new { Weather = "Rainy" });
    }

    #endregion
}
