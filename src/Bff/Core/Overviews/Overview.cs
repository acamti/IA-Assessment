namespace IA.Assessment.BFF.Core.Overviews;

public sealed class Overview
{
    public string ContinentName { get; set; }

    public string CountryName { get; set; }

    public string FlagURL { get; set; }

    public int YearEstablished { get; set; }

    public bool HasIncentive { get; set; }

    public decimal TradeVolume { get; set; }
}
