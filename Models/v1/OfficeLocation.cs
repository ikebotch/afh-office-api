using System.Text.Json.Serialization;

namespace AFHOfficeApp.Models.v1
{
    public class OfficeLocation
    {
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? Postcode { get; set; }
        [JsonPropertyName("map_url")]
        public string? MapUrl { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Email { get; set; }
    }
}