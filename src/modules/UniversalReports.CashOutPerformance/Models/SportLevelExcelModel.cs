using System.Collections.Generic;

namespace UniversalReports.CashOutPerformance.Models
{
    public class SportLevelExcelModel
    {
        public IEnumerable<SportExcelModel> Sports { get; set; }

        public SportItemExcelModel GrandTotal { get; set; }

        public int TotalItems { get; set; }
    }
}