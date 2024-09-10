using System.Collections.Generic;

namespace UniversalReports.BetConstructPerformance.Models
{
    public class SportModel
    {
        public IEnumerable<SportItemModel> Items { get; set; }

        public SportItemModel Total { get; set; }
    }
}
