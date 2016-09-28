using System;
using Fanex.Data.Repository;

namespace UniversalReports.NG2Statistic.Data
{
    public class CommonCriteria : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime MoveBetsDay { get; set; }

        public string UserName { get; set; }

        public string BetType { get; set; }

        public short LiveStatus { get; set; } = -1;

        public short Currency { get; set; }

        public bool IsRealTime { get; set; } = true;

        public override bool IsValid()
        {
            return true;
        }
    }
}
