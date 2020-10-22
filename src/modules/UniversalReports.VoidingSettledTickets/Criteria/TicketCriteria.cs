using Fanex.Data.Repository;
using System;

namespace UniversalReports.VoidingSettledTickets.Criteria
{
    public class TicketCriteria : CriteriaBase
    {
        public DateTime WinlostDate { get; set; }

        public int? MatchId { get; set; }

        public DateTime? VoidTime { get; set; }

        public int ProductGroupId { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public override string GetSettingKey() => "Acc_Rpt_VoidingSettledTicket_Product";

        public override bool IsValid() => !string.IsNullOrWhiteSpace(WinlostDate.ToString());
    }
}