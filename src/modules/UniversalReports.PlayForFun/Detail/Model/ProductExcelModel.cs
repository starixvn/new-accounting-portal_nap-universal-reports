using Epplus.Mapper.Annotations;

namespace UniversalReports.PlayForFun.Detail.Model
{
    public class DetailExcelModel
    {
        [Cell("A8")]
        public string Username { get; set; }

        [Cell("B8")]
        public decimal WinLoss { get; set; }

        [Cell("C8")]
        public decimal Turnover { get; set; }

        [Cell("D8")]
        public object Margin { get; set; }

        [Cell("E8")]
        public int BetCount { get; set; }
    }
}
