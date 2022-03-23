using System;

namespace UniversalReports.CashOutPerformance.Models
{
    public class CommonTicketModel
    {
        public decimal COTurnover_RM { get; set; }

        public decimal BBAmount_RM { get; set; }

        public decimal MemberWL_RM { get; set; }

        public decimal Comm_RM { get; set; }

        public decimal COIncome_RM { get; set; }

        public decimal TotalIncome_RM { get; set; }

        public decimal? ActualTurnover { get; set; }

        public decimal? AssumedPayout { get; set; }

        public decimal? HypGGR { get; set; }

        public decimal? COProfit { get; set; }

        public decimal? Margin => ActualTurnover == null || ActualTurnover == 0 ? 0 : COProfit / ActualTurnover;
    }
}