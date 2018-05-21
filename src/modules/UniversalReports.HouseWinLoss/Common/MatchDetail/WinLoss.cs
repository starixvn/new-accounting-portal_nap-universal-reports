using System;

namespace UniversalReports.HouseWinLoss.Common.MatchDetail
{
    public class WinLoss
    {
        public int MatchId { get; set; }

        public string MatchCode { get; set; }

        public DateTime EventDate { get; set; }

        public int SportType { get; set; }

        public bool IsNeutral { get; set; }

        public int HomeId { get; set; }

        public int AwayId { get; set; }

        public string HomeName { get; set; }

        public string AwayName { get; set; }

        public int LeagueId { get; set; }

        public string LeagueName { get; set; }

        public decimal MemberWinLoss { get; set; }

        public decimal SMAWinLoss { get; set; }

        public decimal Commission { get; set; }

        public decimal RealIncome { get; set; }

        public decimal VirtualIncome { get; set; }

        public decimal VarianceIncome { get; set; }

        public decimal RealTurnover { get; set; }

        public decimal VirtualTurnover { get; set; }

        public decimal RealMargin
        {
            get
            {
                return RealTurnover != 0
                       ? Math.Round(RealIncome / RealTurnover, 4, MidpointRounding.AwayFromZero)
                       : 0;
            }
        }

        public decimal VirtualMargin
        {
            get
            {
                return VirtualTurnover != 0
                      ? Math.Round(VirtualIncome / VirtualTurnover, 4, MidpointRounding.AwayFromZero)
                      : 0;
            }
        }

        public decimal ExtraPT { get; set; }
    }
}