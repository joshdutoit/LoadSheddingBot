using System.Globalization;
using System.Text.Json;
using ClassLibrary.Models;
using CsvHelper;
using RestSharp;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace DiscordLoadsheddingApi.Services;

public class EskomService
{
    private readonly RestClient _client;
    
    public EskomService()
    {
        _client = new RestClient("https://loadshedding.eskom.co.za/LoadShedding");
    }
    
    public async Task<Stage.LoadSheddingStage> GetLoadSheddingStage()
    {
        try
        {
            var request = new RestRequest("/GetStatus");

            return await _client.GetAsync<Stage.LoadSheddingStage>(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return Stage.LoadSheddingStage.Unknown;
    }

    public async Task<List<Municipality>?> GetMunicipality(Provinces province)
    {
        try
        {
            var request = new RestRequest($"/GetMunicipalities/?Id={(int) province}");

            return await _client.GetAsync<List<Municipality>>(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return new List<Municipality>() { };
    }
    
    public async Task<List<SuburbsData>?> GetSuburbsData(Municipality municipality)
    {
        try
        {
            var request = new RestRequest($"/GetSurburbData/?pageSize=100&pageNum=1&id=342");

            return await _client.GetAsync<List<SuburbsData>>(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return new List<SuburbsData>() {};
    }

    public List<Schedule> GetSchedule(int zone)
    {
        var baseDirectory = Directory.GetCurrentDirectory();
        var path = "Schedules";
        var fullPath = Path.Combine(baseDirectory, path, $"city-of-cape-town-area-{zone}.csv");
        var today = DateTime.Today.Day;
        var stage = GetLoadSheddingStage().Result;
        int stageToInt = (int) stage;
        
        using (var streamReader = new StreamReader(fullPath))
        {
            using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                var fullSchedule = csvReader.GetRecords<Schedule>().ToList();

                var todaySchedules = fullSchedule.Where(x => x.DayOfMonth == today).Where(x => x.Stage == stageToInt).ToList();
                return todaySchedules;
            }
        }
    }
}