using System;
using Fanex.Data;
using Fanex.Data.Repository;

namespace UniversalReports.CN88WinLoss.Common.Criteria
{
    public abstract class WinLossCriteria : CriteriaBase
    {
        [SpParam(Ignored = true)]
        public bool NormalMode { get; set; } = true;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [SpParam(Ignored = true)]
        public string Source { get; set; }

        public override bool IsValid() => true;
    }
}