using System.Collections.Generic;

namespace UniversalReports.NG2Statistic.Data.GrandTotal
{
    public class GrandTotalModel
    {
        public GrandTotalModel()
        {
            Rows = new List<GrandTotalRaw>();
            GrandTotal = new List<GrandTotalRaw>();
        }

        public List<GrandTotalRaw> Rows { get; set; }

        public List<GrandTotalRaw> GrandTotal { get; set; }
    }
}