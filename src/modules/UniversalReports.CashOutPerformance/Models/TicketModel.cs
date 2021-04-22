using System;

namespace UniversalReports.CashOutPerformance.Models
{
    public class TicketModel
    {
        public DateTime WLDate { get; set; }

        public string Username { get; set; }

        public long OrigID { get; set; }

        public long BuyBackID { get; set; }

        public long CashOutID { get; set; }

        public string LeagueName { get; set; }

        public string MatchName { get; set; }

        public DateTime BetTime { get; set; }

        public DateTime CashOutTime { get; set; }

        public string BetOdd { get; set; }

        public string BetTypeName { get; set; }

        public string BetChoice { get; set; }

        public decimal COTurnover { get; set; }

        public decimal BBAmount { get; set; }

        public decimal MemberWL { get; set; }

        public decimal COTurnover_RM { get; set; }

        public decimal BBAmount_RM { get; set; }

        public decimal MemberWL_RM { get; set; }

        public decimal Comm_RM { get; set; }

        public decimal COIncome_RM { get; set; }

        public decimal TotalIncome_RM { get; set; }
    }
}
