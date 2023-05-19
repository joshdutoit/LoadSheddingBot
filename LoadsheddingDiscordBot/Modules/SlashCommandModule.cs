using ClassLibrary;
using Discord;
using Discord.Interactions;
using DiscordLoadsheddingApi.Services;
using Microsoft.OpenApi.Extensions;

namespace LoadsheddingDiscordBot.Modules;

public class SlashCommandModule : InteractionModuleBase<SocketInteractionContext>
{
    private EskomService _eskomService = new EskomService();
    #region Commands

    [SlashCommand("subscribe", "subscribe to a new zone")]
    public async Task Subscribe()
    {
        
    }
    
    [SlashCommand("checkstage", "checks the current loadshedding stage")]
    public async Task CheckStage()
    {
        var stageResult = _eskomService.GetLoadSheddingStage().Result;
        var displayValue = EnumValue.GetValue(stageResult);

        await RespondAsync($"We are currently in {displayValue}");
    }

    [SlashCommand("schedule", "checks the current schedule for a given area")]
    public async Task GetSchedule()
    {
        var result = _eskomService.GetScheduleData(1058696, 4, 9);

        var embed = new EmbedBuilder()
        {
            Description = $"{result.Result}"
        }; 

        await RespondAsync(embed: embed.Build());
    }
    #endregion Commands
}