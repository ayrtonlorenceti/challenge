using System.Text.Json.Serialization;

namespace AfterShip_challenge
{
    public class ExchangeRate
    {
        public string disclaimer { get; set; }
        public string license { get; set; }
        public long timestamp { get; set; }

        [JsonPropertyName("base")]
        public string baseCurrency { get; set; }
        public Dictionary<string, double> rates { get; set; }
    }
}