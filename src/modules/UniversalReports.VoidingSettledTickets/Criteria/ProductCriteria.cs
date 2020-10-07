using Fanex.Data.Repository;
using System;

namespace UniversalReports.VoidingSettledTickets.Criteria
{
    public class ProductCriteria : CriteriaBase
    {
        public DateTime WinlostDate { get; set; }

        public int MatchId { get; set; }

        public DateTime VoidTime { get; set; }

        public override string GetSettingKey() => "Acc_Rpt_VoidingSettledTicket";

        public override bool IsValid() => !string.IsNullOrWhiteSpace(WinlostDate.ToString());
    }
}