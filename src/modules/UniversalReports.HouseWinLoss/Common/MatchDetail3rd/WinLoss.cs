using System;

namespace UniversalReports.HouseWinLoss.Common.MatchDetail3rd
{
    public class WinLoss
    {
        public string League { get; set; }

        public string MatchCode { get; set; }

        public string HomeName { get; set; }

        public string AwayName { get; set; }

        public decimal MemberWinLoss { get; set; }

        public decimal SMAWinLoss { get; set; }

        public decimal Commission { get; set; }

        public decimal RealIncome { get; set; }

        public decimal RealTurnover { get; set; }

        public decimal RealMargin
        {
            get
            {
                return RealTurnover != 0
                       ? Math.Round(RealIncome / RealTurnover, 4, MidpointRounding.AwayFromZero)
                       : 0;
            }
        }
    }
}
