using Refit;
using SearchAPI.Builders;
using SearchAPI.Handlers;
using SearchAPI.Providers;
using SearchAPI.Services;
using System.Text.Json.Serialization;
using static SearchAPI.Models.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
        .AddControllersAsServices()
        .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Add builder
builder.Services.AddSingleton<IDashboardResponseBuilder, DashboardResponseBuilder>();

// Add services
builder.Services.AddSingleton<ISearchApiServiceProvider>(sp =>
{
    var provider = sp.GetRequiredService<ISearchRefitDataProvider>();
    var logger = sp.GetRequiredService<ILogger<SearchApiServiceProvider>>();
    return new SearchApiServiceProvider(provider, logger);
});
builder.Services.AddSingleton<IDashboardService>(sp =>
{
    var provider = sp.GetRequiredService<ISearchApiServiceProvider>();
    return new DashboardService(provider);
});

// Add Refit Search API
builder.Services.AddRefitClient<ISearchRefitDataProvider>()
    .ConfigurePrimaryHttpMessageHandler(sp =>
    {
        return new SearchHttpAuthHandler(
            sp.GetRequiredService<ILogger<SearchHttpAuthHandler>>(),
            sp.GetRequiredService<IConfiguration>());
    })
    .ConfigureHttpClient((sp, c) =>
    {
        c.BaseAddress = new Uri(ConfigKeys.SearchServiceEndpoint);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.MapControllers();
app.UseExceptionHandler(options => { options.Run(ExceptionHandler.HandleExceptionAsync); });
app.Run();
