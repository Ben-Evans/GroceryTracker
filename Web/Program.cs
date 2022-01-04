try
{
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateBootstrapLogger();

    Log.Information($"Starting WebApplication.CreateBuilder()...");
    var builder = WebApplication.CreateBuilder(args);
    Log.Information($"Completed WebApplication.CreateBuilder().");

    Log.Logger.LogCompletion(builder.AddSerilog);

    Log.Logger.LogCompletion(builder.AddAppSettings);

    Log.Logger.LogCompletion(builder.AddDbContext);

    /*Log.Logger.LogCompletion(() =>
        builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>(),
            "AddDefaultIdentity / AddEntityFrameworkStores"
        );

    Log.Logger.LogCompletion(() =>
        builder.Services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(),
        "AddIdentityServer / AddDefaultIdentity"
        );

    Log.Logger.LogCompletion(() => 
        builder.Services.AddAuthentication()
            .AddIdentityServerJwt(),
        "AddAuthentication / AddIdentityServerJwt"
        );*/

    Log.Logger.LogCompletion(builder.AddMappings);
    Log.Logger.LogCompletion(builder.AddValidators);
    Log.Logger.LogCompletion(builder.AddRepositories);
    Log.Logger.LogCompletion(builder.AddCoreServices);
    Log.Logger.LogCompletion(builder.AddSwagger);

    Log.Logger.LogCompletion(() => builder.Services.AddControllersWithViews(), "AddControllersWithViews"); // TODO: Vs. builder.Services.AddControllers();
    Log.Logger.LogCompletion(() => builder.Services.AddRazorPages(), "AddRazorPages");

    Log.Information($"Starting builder.Build()...");
    var app = builder.Build();
    Log.Information($"Completed builder.Build().");

    // Configure the HTTP request pipeline.
    Log.Information("Starting app.Environment.IsDevelopment()...");
    var isDev = app.Environment.IsDevelopment();
    Log.Information("Completed app.Environment.IsDevelopment().");
    if (isDev)
    {
        Log.Logger.LogCompletion(() => app.UseDeveloperExceptionPage(), "UseDeveloperExceptionPage");

        // Reminder to apply unapplied DB Migrations
        Log.Logger.LogCompletion(() => app.UseMigrationsEndPoint(), "UseMigrationsEndPoint");

        // https://localhost:<port>/swagger
        // https://localhost:<port>/swagger/v1/swagger.json
        Log.Logger.LogCompletion(() => app.UseSwagger(), "UseSwagger");
        Log.Logger.LogCompletion(() => app.UseSwaggerUI(), "UseSwaggerUI");
    }
    else
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        Log.Logger.LogCompletion(() => app.UseHsts(), "UseHsts");
    }

    // app.UseSerilogRequestLogging();

    Log.Logger.LogCompletion(() => app.UseHttpsRedirection(), "UseHttpsRedirection");
    Log.Logger.LogCompletion(() => app.UseStaticFiles(), "UseStaticFiles");
    Log.Logger.LogCompletion(() => app.UseRouting(), "UseRouting");

    /*Log.Logger.LogCompletion(() => app.UseAuthentication(), "UseAuthentication");
    Log.Logger.LogCompletion(() => app.UseIdentityServer(), "UseIdentityServer");
    Log.Logger.LogCompletion(() => app.UseAuthorization(), "UseAuthorization");*/

    Log.Logger.LogCompletion(() =>
        app.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}"),
        "MapControllerRoute"
        );
    Log.Logger.LogCompletion(app.MapApiControllers);
    Log.Logger.LogCompletion(() => app.MapRazorPages(), "MapRazorPages");

    Log.Logger.LogCompletion(() => app.MapFallbackToFile("index.html"), "MapFallbackToFile");

    Log.Logger.LogCompletion(app.Run);
}
catch (Exception ex)
{
    /* Expected exception meant to fail the application before builder.Build() has a chance to start the app.
     * https://andrewlock.net/exploring-dotnet-6-part-5-supporting-ef-core-tools-with-webapplicationbuilder/
     * 
     * Check required when running Migration tools
     * https://githubmate.com/repo/dotnet/runtime/issues/60600
     */
    if (ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal)) throw;

    Log.Fatal(ex, "The application failed to start.");
}
finally
{
    Log.Logger.LogCompletion(Log.CloseAndFlush);
}
