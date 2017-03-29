using System.Collections.Generic;

namespace UniversalReports.NG2Statistics.UserName
{
    public class UserNameModel
    {
        public UserNameModel()
        {
            Rows = new List<UserNameModel>();
        }

        public string Username { get; set; }

        public int CustId { get; set; }

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

        public List<UserNameModel> Rows { get; set; }

        public UserNameModel Total { get; set; }
    }
}