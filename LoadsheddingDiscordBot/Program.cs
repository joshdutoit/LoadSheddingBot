using System.Reflection;
using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using LoadsheddingDiscordBot;
using LoadsheddingDiscordBot.Modules;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        services.AddSingleton(config);
        services.AddHostedService<Worker>();
        services.AddSingleton(x => new DiscordSocketClient(new DiscordSocketConfig()
        {
            GatewayIntents = GatewayIntents.AllUnprivileged,
            AlwaysDownloadUsers = true
        }));
        services.AddSingleton(x => new InteractionService(x.GetRequiredService<DiscordSocketClient>()));
        services.AddSingleton<SlashCommandHandler>();
    })
    .Build();

InitializeDiscordClient(host);

host.Run();

async void InitializeDiscordClient(IHost host)
{
    using IServiceScope serviceScope = host.Services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    
    var config = provider.GetRequiredService<IConfigurationRoot>();
    var client = provider.GetRequiredService<DiscordSocketClient>();
    var slashCommands = provider.GetRequiredService<InteractionService>();

    await provider.GetRequiredService<SlashCommandHandler>().Initialize();
    
    client.Ready += () =>
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Connected To Discord");
        slashCommands.RegisterCommandsGloballyAsync();
        return Task.CompletedTask;
    };

    var token = config.GetValue<string>("Token");

    await client.LoginAsync(TokenType.Bot, token);
    await client.StartAsync();

    await Task.Delay(-1);
}