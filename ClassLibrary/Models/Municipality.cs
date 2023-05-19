using System.Text.Json.Serialization;

namespace ClassLibrary.Models;

public class Municipality
{
    [JsonPropertyName("Text")]
    public string Name { get; set; }
        
    [JsonPropertyName("Value")]
    public string ID { get; set; }
}