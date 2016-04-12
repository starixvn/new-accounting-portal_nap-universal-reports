using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Products
{
    public static class Constants
    {
        public static readonly List<string> NameSportsbook = new List<string>
        {
            "Soccer",
            "Metric Gaming - Superlive",
            "Other Sports",
            "Parlay",
            "Sportsbook Total",
            "Sportsbook Live Total",
            "Sportsbook Non-Live Total",
            "RM"
        };

        public static readonly List<string> NamesExclude = new List<string>
        {
            "Sportsbook Total",
            "Sportsbook Live Total",
            "Sportsbook Non-Live Total",
        };
    }
}
