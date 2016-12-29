using Fanex.Data.Repository;
using System;

namespace UniversalReports.NG2Statistics.BaseServices
{
    public class NG2CriteriaBase : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime MoveBetsDay { get; set; }

        public string UserName { get; set; }

        public string BetType { get; set; }

        public short LiveStatus { get; set; } = -1;

        public short Currency { get; set; }

        public bool IsRealTime { get; set; } = true;

        public override bool IsValid() => true;

        public override string GetSettingKey()
        {
            throw new NotImplementedException();
        }
    }
}
