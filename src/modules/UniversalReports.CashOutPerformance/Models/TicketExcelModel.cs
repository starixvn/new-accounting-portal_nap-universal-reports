using Epplus.Mapper.Annotations;
using System;

namespace UniversalReports.CashOutPerformance.Models
{
    public class TicketExcelModel
    {
        private string dateTime;
        private string betTime;
        private string cashOutTime;

        [Cell("A4")]
        public string WLDate
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(dateTime))
                {
                    var date = DateTime.Parse(dateTime);
                    return date.ToString("yyyy-MM-dd");
                }

                return dateTime;
            }
            set
            {
                dateTime = value;
            }
        }

        [Cell("B4")]
        public string Username { get; set; }

        [Cell("C4")]
        public string Currency { get; set; }

        [Cell("D4")]
        public long OrigID { get; set; }

        [Cell("E4")]
        public long BuyBackID { get; set; }

        [Cell("F4")]
        public long CashOutID { get; set; }
        
        [Cell("G4")]
        public string SportName { get; set; }

        [Cell("H4")]
        public string LeagueName { get; set; }

        [Cell("I4")]
        public string MatchName { get; set; }

        [Cell("J4")]
        public string BetTime
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(betTime))
                {
                    var date = DateTime.Parse(betTime);
                    return date.ToString("yyyy-MM-dd hh:mm:ss tt");
                }

                return betTime;
            }
            set
            {
                betTime = value;
            }
        }

        [Cell("K4")]
        public string CashOutTime
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(cashOutTime))
                {
                    var date = DateTime.Parse(cashOutTime);
                    return date.ToString("yyyy-MM-dd hh:mm:ss tt");
                }

                return cashOutTime;
            }
            set
            {
                cashOutTime = value;
            }
        }

        [Cell("L4")]
        public string BetOdd { get; set; }

        [Cell("M4")]
        public string BetTypeName { get; set; }

        [Cell("N4")]
        public string BetChoice { get; set; }

        [Cell("O4")]
        public decimal COTurnover { get; set; }

        [Cell("P4")]
        public decimal BBAmount { get; set; }

        [Cell("Q4")]
        public decimal MemberWL { get; set; }

        [Cell("R4")]
        public decimal COTurnover_RM { get; set; }

        [Cell("S4")]
        public decimal BBAmount_RM { get; set; }

        [Cell("T4")]
        public decimal MemberWL_RM { get; set; }

        [Cell("U4")]
        public decimal Comm_RM { get; set; }

        [Cell("V4")]
        public decimal COIncome_RM { get; set; }

        [Cell("W4")]
        public decimal TotalIncome_RM { get; set; }
    }
}