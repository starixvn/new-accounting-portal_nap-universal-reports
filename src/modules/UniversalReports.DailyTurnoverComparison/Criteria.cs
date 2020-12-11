using Fanex.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalReports.DailyTurnoverComparison
{
    public class Criteria : CriteriaBase
    {
        public DateTime ToDate { get; set; }

        public int Top { get; set; }

        public override string GetSettingKey() => "Acc_Rpt_SBTurnoverComparision_Daily";

        public override bool IsValid() => true;
    }
}