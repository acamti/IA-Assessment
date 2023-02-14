using System.Collections.Generic;

namespace IA.Assessment.BFF.Core.Overviews;

public sealed class Overview
{
    public string ContinentName { get; set; }

    public IEnumerable<CountryOverview> Countries { get; set; }

    public class CountryOverview
    {
        public string ExchangeName { get; set; }

        public string CountryName { get; set; }

        public string CountryFlagURL { get; set; }

        public int? YearEstablished { get; set; }

        public bool? HasIncentive { get; set; }

        public decimal TradeVolume { get; set; }
    }
}
