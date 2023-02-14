using Newtonsoft.Json;

namespace IA.Assessment.Continent.Core;

public class Country
{
    [JsonProperty("name")]
    public CountryName Name { get; set; }

    [JsonProperty("cca3")]
    public string Iso3 { get; set; }

    public class CountryName
    {
        [JsonProperty("common")]
        public string Common { get; set; }
    }
}
