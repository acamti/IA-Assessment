namespace IA.Assessment.BFF.Core.Exchanges;

public class Exchange
{
    public string Id { get; set; }

    public string Name { get; set; }

    public int? YearEstablished { get; set; }

    public string Country { get; set; }

    public string Description { get; set; }

    public bool? HasTradingIncentive { get; set; }

    public int? TrustScore { get; set; }

    public decimal TradeVolume { get; set; }

    public string CountryCodeIso2 { get; set; }
}
