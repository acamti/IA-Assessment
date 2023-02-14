using Newtonsoft.Json;
using System.Collections.Generic;

namespace IA.Assessment.Continent.Infrastructure;

public class CountriesResult
{
    [JsonProperty("data")]
    public IEnumerable<CountryDetails> Countries { get; set; }

    public class CountryDetails
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("popyear")]
        public string Year { get; set; }

        [JsonProperty("continent")]
        public string Continent { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("iso3")]
        public string Iso3 { get; set; }
    }
}
