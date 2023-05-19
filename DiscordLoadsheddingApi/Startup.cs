using DiscordLoadsheddingApi.Controllers;
using DiscordLoadsheddingApi.Services;

namespace DiscordLoadsheddingApi;

public class Startup
{
    private IHostEnvironment WebHostEnvironment { get; }

    public Startup(IHostEnvironment webHostEnvironment)
    {
        WebHostEnvironment = webHostEnvironment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRouting(options => options.LowercaseUrls = true);

        services.AddScoped<EskomService>();
        services.AddTransient<LoadsheddingController>();
    }
}