using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalReports.NG2Statistic.Data.Daily
{
    public class DailyModel
    {
        public string Name { get; set; }

        public int NoOfPlayers { get; set; }

        public int BetCount { get; set; }

        public string Currency { get; set; }

        public decimal TotalBets { get; set; }

        public decimal TotalWins { get; set; }

        public decimal GameIncome { get; set; }

        public decimal GamePayout { get; set; }

        public decimal CompanyTurnover { get; set; }

        public decimal CompanyComm { get; set; }

        public decimal CompanyNetIncome { get; set; }
    }
}
