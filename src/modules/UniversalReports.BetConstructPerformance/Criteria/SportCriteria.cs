using Fanex.Data.Repository;
using System;

namespace UniversalReports.BetConstructPerformance.Criteria
{
    public class SportCriteria : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public bool NoDraw { get; set; }

        public int? SportId { get; set; }

        public override string GetSettingKey() => "Acc_Rpt_BetConstructPerformance";

        public override bool IsValid() => true;
    }
}
