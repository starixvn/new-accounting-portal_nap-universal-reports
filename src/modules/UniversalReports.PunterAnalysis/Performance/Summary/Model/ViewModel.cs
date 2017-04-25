using System.Collections.Generic;

namespace UniversalReports.PunterAnalysis.Performance.Summary.Model
{
    public class ViewModel
    {
        public SummaryStatistic SummaryStatistic { get; set; }

        public List<MonthStatistic> MonthStatistics { get; set; }

        public List<ProductTurnoverStatistic> ProductTurnoverStatistics { get; set; }

        public List<SportStatistic> SportStatistics { get; set; }

        public List<EventStatistic> BetTypeStatistics { get; set; }

        public List<EventStatistic> EventStatistics { get; set; }
    }
}