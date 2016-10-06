using System.Collections.Generic;

namespace UniversalReports.NG2Statistic.Bettype
{
    public class BettypeModel
    {
        public BettypeModel()
        {
            Rows = new List<BettypeModel>();
        }

        public string Name { get; set; }

        public int SportId { get; set; }

        public string Bettype { get; set; }

        public int BettypeId { get; set; }

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

        public List<BettypeModel> Rows { get; set; }

        public BettypeModel Total { get; set; }
    }
}
