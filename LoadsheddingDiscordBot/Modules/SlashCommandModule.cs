using System.Globalization;
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
    public async Task GetSchedule(int zone)
    {
        var response = _eskomService.GetSchedule(zone);
        var stageResult = _eskomService.GetLoadSheddingStage().Result;
        var stageDisplayValue = EnumValue.GetValue(stageResult);

        var embed = new EmbedBuilder();

        embed.Description += $"**Today's Schedule for zone {zone} \n {stageDisplayValue}** \n \n";
        
        foreach (var item in response)
        {
            embed.Description += $"\n {item.StartTime.Hour}:{item.StartTime.Minute} - {item.EndTime.Hour}:{item.EndTime.Minute}";
        }

        await RespondAsync(embed: embed.Build());
    }
    
    #endregion Commands
}