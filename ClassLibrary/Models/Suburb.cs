using System.Text.Json.Serialization;

namespace ClassLibrary.Models;

public class Suburb
{
    [JsonPropertyName("text")]
    public string? Name { get; set; }
        
    [JsonPropertyName("id")]
    public string? ID { get; set; }
}