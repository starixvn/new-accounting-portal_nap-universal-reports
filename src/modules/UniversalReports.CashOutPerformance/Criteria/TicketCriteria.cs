using Fanex.Data.Repository;
using System;

namespace UniversalReports.CashOutPerformance.Criteria
{
    public class TicketCriteria : CriteriaBase
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Sports { get; set; }

        public string Sites { get; set; }

        public string LeagueId { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public override string GetSettingKey() => "Acc_Rpt_COPerformance";

        public override bool IsValid() => true;
    }
}