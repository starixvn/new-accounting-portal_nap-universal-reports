using Fanex.Data.Repository;
using System;

namespace UniversalReports.AbnormalBet.Criteria
{
    public class MemberQueryCriteria : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Reason { get; set; }

        public string Sport { get; set; }

        public string BetType { get; set; }

        public string Licensee { get; set; }

        public string Member { get; set; }

        public bool IsTest { get; set; }

        public override bool IsValid() => true;

        public override string GetSettingKey() => $"Acc_Rpt_AbnormalBet_Member";
    }
}
