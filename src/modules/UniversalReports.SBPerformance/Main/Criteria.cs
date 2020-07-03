using Fanex.Data;
using Fanex.Data.Repository;
using System;

namespace UniversalReports.SBPerformance.Main
{
    public class Criteria : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int TimeRange { get; set; }

        public bool IsShowSite { get; set; }

        public bool IsShowSport { get; set; }

        public bool IsShowLeague { get; set; }

        public bool IsShowCust { get; set; }

        public decimal Margin { get; set; }

        public int Top { get; set; }

        [SpParam(Ignored = true)]
        public string Source { get; set; }

        public override string GetSettingKey() => $"SBPerformanceMonitor-Dashboard-{Source}";

        public override bool IsValid() => true;
    }
}