using System.Text.Json.Serialization;

namespace ClassLibrary.Models;

public class SuburbsData
{
    [JsonPropertyName("Results")]
    public List<Suburb>? Results { get; set; }
    
    [JsonPropertyName("Total")]
    public int Total { get; set; }
}