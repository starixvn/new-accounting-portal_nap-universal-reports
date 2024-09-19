using System.Collections.Generic;

namespace UniversalReports.BetConstructPerformance.Models
{
    public class SportDetailExcelModel
    {
        public IEnumerable<SportDetailItemExcelModel> Items { get; set; }

        public SportDetailItemExcelModel Total { get; set; }
    }
}
