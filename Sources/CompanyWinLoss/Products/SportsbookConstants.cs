using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class SportsbookConstants
    {
        public List<string> listName = new List<string>
        {
            "Soccer",
            "Metric Gaming - Superlive",
            "Other Sports",
            "Parlay",
            "MetricGaming Total",
            "MetricGaming Live Total",
            "MetricGaming Non-Live Total",
            "RM"
        };

        public List<string> listExclude = new List<string>
        {
            "MetricGaming Total",
            "MetricGaming Live Total",
            "MetricGaming Non-Live Total",
        };
    }
}
