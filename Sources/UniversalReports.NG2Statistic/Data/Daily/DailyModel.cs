using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalReports.NG2Statistic.Data.Daily
{
    public class DailyModel
    {
        public DailyModel()
        {
            Rows = new List<DailyRaw>();
            GrandTotal = new List<DailyRaw>();
        }

        public List<DailyRaw> Rows { get; set; }

        public List<DailyRaw> GrandTotal { get; set; }
    }
}
