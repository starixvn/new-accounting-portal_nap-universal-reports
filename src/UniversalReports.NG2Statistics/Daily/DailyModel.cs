using System;
using System.Collections.Generic;

namespace UniversalReports.NG2Statistics.Daily
{
    public class DailyModel
    {
        public DailyModel()
        {
            Rows = new List<DailyModel>();
        }

        public string Name { get; set; }

        public DateTime Winlostdate { get; set; }

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

        public List<DailyModel> Rows { get; set; }

        public DailyModel Total { get; set; }
    }
}
