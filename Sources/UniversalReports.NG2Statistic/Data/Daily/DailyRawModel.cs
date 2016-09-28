using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalReports.NG2Statistic.Data.Daily
{
    public class DailyRawModel
    {
        public DailyRawModel()
        {
            Rows = new List<DailyRaw>();
            GrandTotal = new DailyRaw();
        }

        public List<DailyRaw> Rows { get; set; }

        public DailyRaw GrandTotal { get; set; }
    }
}
