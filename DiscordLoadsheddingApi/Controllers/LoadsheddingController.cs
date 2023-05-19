using ClassLibrary.Models;
using DiscordLoadsheddingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiscordLoadsheddingApi.Controllers;

public class LoadsheddingController : HttpClient
{
    private EskomService _eskomService = new EskomService();
    
    [HttpGet("getstage")]
    public async Task<Stage.LoadSheddingStage> GetLoadSheddingStage()
    {
        return await _eskomService.GetLoadSheddingStage();
    }
    
    [HttpGet("getmunicipalities")]
    public async Task<List<Municipality>?> GetMunicipalities(Provinces province)
    {
        return await _eskomService.GetMunicipality(province);
    }
    
    [HttpGet("getsuburbs")]
    public async Task<List<SuburbsData>?> GetSuburbs(Municipality municipality)
    {
        return await _eskomService.GetSuburbsData(municipality);
    }
    
    [HttpGet("getschedule")]
    public async Task<string?> GetSchedule(int suburb, int stage, int province)
    {
        return await _eskomService.GetScheduleData(suburb, stage, province);
    }
}