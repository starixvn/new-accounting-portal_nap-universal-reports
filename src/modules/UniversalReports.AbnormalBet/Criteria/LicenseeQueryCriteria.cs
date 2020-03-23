using Fanex.Data.Repository;
using System;

namespace UniversalReports.AbnormalBet.Criteria
{
    public class LicenseeQueryCriteria : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int Reason { get; set; }

        public int Sport { get; set; }

        public int BetType { get; set; }

        public int Licensee { get; set; }

        public bool IsTest { get; set; }

        public override bool IsValid() => true;

        public override string GetSettingKey() => $"Acc_Rpt_AbnormalBet_Licensee";
    }
}
