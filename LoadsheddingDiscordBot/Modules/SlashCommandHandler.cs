using System.Reflection;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using IResult = Discord.Interactions.IResult;

namespace LoadsheddingDiscordBot.Modules;

public class SlashCommandHandler : ModuleBase<SocketCommandContext>
{
    private readonly DiscordSocketClient _client;
    private readonly InteractionService _commands;
    private readonly IServiceProvider _services;

    public SlashCommandHandler(
        DiscordSocketClient client,
        InteractionService commands,
        IServiceProvider services)
    {
        _client = client;
        _commands = commands;
        _services = services;
    }

    public async Task Initialize()
    {
        await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);

        _client.InteractionCreated += HandleInteraction;
        _commands.SlashCommandExecuted += SlashCommandExecuted;
        _commands.ContextCommandExecuted += ContextCommandExecuted;
        _commands.ComponentCommandExecuted += ComponentCommandExecuted;
    }
    
    private Task ComponentCommandExecuted(ComponentCommandInfo arg1, Discord.IInteractionContext arg2, IResult arg3)
    {
        return Task.CompletedTask;
    }

    private Task ContextCommandExecuted(ContextCommandInfo arg1, Discord.IInteractionContext arg2, IResult arg3)
    {
        return Task.CompletedTask;
    }

    private Task SlashCommandExecuted(SlashCommandInfo arg1, Discord.IInteractionContext arg2, IResult arg3)
    {
        return Task.CompletedTask;
    }

    private async Task HandleInteraction(SocketInteraction args)
    {
        try
        {
            var context = new SocketInteractionContext(_client, args);
            await _commands.ExecuteCommandAsync(context, _services);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}