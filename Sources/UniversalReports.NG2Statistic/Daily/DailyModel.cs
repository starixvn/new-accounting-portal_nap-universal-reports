using System.Collections.Generic;

namespace UniversalReports.NG2Statistic.Daily
{
    public class DailyModel
    {
        public DailyModel()
        {
            Rows = new List<DailyModel>();
        }

        public string Name { get; set; }

        public int NoOfPlayers { get; set; }

        public int BetCount { get; set; }

        public int CurrencyId { get; set; }

        public string Currency { get; set; }

        public decimal TotalBets { get; set; }

        public decimal TotalWins { get; set; }

        public decimal GameIncome { get; set; }

        public decimal GamePayout { get; set; }

        public decimal CompanyTurnover { get; set; }

        public decimal CompanyComm { get; set; }

        public decimal CompanyNetIncome { get; set; }

        public List<DailyModel> Rows { get; set; }

        public DailyModel Total { get; set; }
    }
}
