using System.Collections.Generic;

namespace UniversalReports.NG2Statistic.GrandTotal
{
    public class GrandTotalModel
    {
        public GrandTotalModel()
        {
            Rows = new List<GrandTotalModel>();
        }

        public string Name { get; set; }

        public int NoOfPlayers { get; set; }

        public int BetCount { get; set; }

        public string Currency { get; set; }

        public decimal TotalBets { get; set; }

        public decimal TotalWins { get; set; }

        public decimal GameIncome { get; set; }

        public decimal GamePayout { get; set; }

        public decimal HouseTurnover { get; set; }

        public decimal HouseGrossIncome { get; set; }

        public decimal HouseComm { get; set; }

        public decimal HouseNetIncome { get; set; }

        public List<GrandTotalModel> Rows { get; set; }

        public GrandTotalModel Total { get; set; }
    }
}