using System.Collections.Generic;

namespace UniversalReports.CashOutPerformance.Models
{
    public class SportExcelModel
    {
        public SportItemExcelModel SportTotal { get; set; }

        public IEnumerable<SportItemExcelModel> ChildItems { get; set; }
    }
}
