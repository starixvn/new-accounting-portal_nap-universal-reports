using Epplus.Mapper.Annotations;

namespace UniversalReports.CashOutPerformance.Models
{
    public class EventStatusLevelExcelModel
    {
        [Cell("A5")]
        public string LiveStatus { get; set; }

        [Cell("B5")]
        public decimal COTurnover_RM { get; set; }

        [Cell("C5")]
        public decimal BBAmount_RM { get; set; }

        [Cell("D5")]
        public decimal MemberWL_RM { get; set; }

        [Cell("E5")]
        public decimal Comm_RM { get; set; }

        [Cell("F5")]
        public decimal COIncome_RM { get; set; }

        [Cell("G5")]
        public decimal TotalIncome_RM { get; set; }
    }
}