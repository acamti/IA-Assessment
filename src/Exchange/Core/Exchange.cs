using Newtonsoft.Json;

namespace IA.Assessment.Exchange.Core;

public class Exchange
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("year_established")]
    public int? YearEstablished { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("has_trading_incentive")]
    public bool? HasTradingIncentive { get; set; }

    [JsonProperty("trust_score")]
    public int? TrustScore { get; set; }
}
