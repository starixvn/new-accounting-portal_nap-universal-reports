using System.Collections.Generic;

namespace UniversalReports.NG2Statistic.UserName
{
    public class UserNameModel
    {
        public UserNameModel()
        {
            Rows = new List<UserNameModel>();
        }

        public string Name { get; set; }

        public int CustId { get; set; }

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

        public List<UserNameModel> Rows { get; set; }

        public UserNameModel Total { get; set; }
    }
}