using System.Collections.Generic;

namespace UniversalReports.NG2Statistic.Bettype
{
    public class BettypeModel
    {
        public BettypeModel()
        {
            Rows = new List<BettypeModel>();
        }

        public string Sporttype { get; set; }

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

        public decimal HouseTurnover { get; set; }

        public decimal HouseGrossIncome { get; set; }

        public decimal HouseComm { get; set; }

        public decimal HouseNetIncome { get; set; }

        public List<BettypeModel> Rows { get; set; }

        public BettypeModel Total { get; set; }
    }
}
