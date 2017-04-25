using System.Collections.Generic;

namespace UniversalReports.PunterAnalysis.Performance.Sportsbook.Model
{
    public class ViewModelJson
    {
        public SummaryStatistic SummaryStatistic { get; set; }

        public List<SportStatistic> SportStatistics { get; set; }

        public List<BetCountStatistic> BetCountStatistics { get; set; }
    }
}