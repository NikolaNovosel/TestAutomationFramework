using System.Text.Json.Serialization;

namespace Business.Model
{
    public class Geo
    {
        [JsonPropertyName("lat")]
        public string? Lat { get; set; }

        [JsonPropertyName("lng")]
        public string? Lng { get; set; }
    }
}
