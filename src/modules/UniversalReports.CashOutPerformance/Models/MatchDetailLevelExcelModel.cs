using Epplus.Mapper.Annotations;
using System;

namespace UniversalReports.CashOutPerformance.Models
{
    public class MatchDetailLevelExcelModel
    {
        private string dateTime;
        private string betTime;
        private string cashOutTime;

        [Cell("A5")]
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

        [Cell("B5")]
        public string Username { get; set; }

        [Cell("C5")]
        public string Currency { get; set; }

        [Cell("D5")]
        public long OrigID { get; set; }

        [Cell("E5")]
        public long BuyBackID { get; set; }

        [Cell("F5")]
        public long CashOutID { get; set; }

        [Cell("G5")]
        public string SportName { get; set; }

        [Cell("H5")]
        public string LeagueName { get; set; }

        [Cell("I5")]
        public string MatchName { get; set; }

        [Cell("J5")]
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

        [Cell("K5")]
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

        [Cell("L5")]
        public string BetOdd { get; set; }

        [Cell("M5")]
        public string BetTypeName { get; set; }

        [Cell("N5")]
        public string BetChoice { get; set; }

        [Cell("O5")]
        public decimal COTurnover { get; set; }

        [Cell("P5")]
        public decimal BBAmount { get; set; }

        [Cell("Q5")]
        public decimal MemberWL { get; set; }

        [Cell("R5")]
        public decimal COTurnover_RM { get; set; }

        [Cell("S5")]
        public decimal BBAmount_RM { get; set; }

        [Cell("T5")]
        public decimal MemberWL_RM { get; set; }

        [Cell("U5")]
        public decimal Comm_RM { get; set; }

        [Cell("V5")]
        public decimal COIncome_RM { get; set; }

        [Cell("W5")]
        public decimal TotalIncome_RM { get; set; }
    }
}