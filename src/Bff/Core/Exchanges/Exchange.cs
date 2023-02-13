namespace IA.Assessment.BFF.Core.Exchanges;

public class Exchange
{
    public string Id { get; set; }

    public string Name { get; set; }

    public int YearEstablished { get; set; }

    public string Country { get; set; }

    public string Description { get; set; }

    public string Url { get; set; }

    public string Image { get; set; }

    public bool HasTradingIncentive { get; set; }

    public int TrustScore { get; set; }

    public int TrustScoreRank { get; set; }

    public decimal TradeVolume24HBtc { get; set; }

    public decimal TradeVolume24HBtcNormalized { get; set; }
}
