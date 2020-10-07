using Fanex.Data.Repository;
using System;

namespace UniversalReports.VoidingSettledTickets.Criteria
{
    public class TicketCriteria : CriteriaBase
    {
        public DateTime WinlostDate { get; set; }

        public int MatchId { get; set; }

        public DateTime VoidedDate { get; set; }

        public string VoidedTime { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public override string GetSettingKey() => "Product";

        public override bool IsValid() => !string.IsNullOrWhiteSpace(WinlostDate.ToString());
    }
}