using System;

namespace UniversalReports.HouseWinLoss.Common.Models
{
    public class WinLoss
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public decimal MemberWinLoss { get; set; }

        public decimal SMAWinLoss { get; set; }

        public decimal Commission { get; set; }

        public decimal RealIncome { get; set; }

        public decimal VirtualIncome { get; set; }

        public decimal VarianceIncome { get; set; }

        public decimal ExtraPT { get; set; }

        public decimal AfterExtraPT { get; set; }

        public decimal RealTurnover { get; set; }

        public decimal VirtualTurnover { get; set; }

        public decimal VirtualMargin
        {
            get
            {
                return VirtualTurnover != 0
                      ? Math.Round(VirtualIncome / VirtualTurnover, 4, MidpointRounding.AwayFromZero)
                      : 0;
            }
        }

        public decimal RealMargin
        {
            get
            {
                return RealTurnover != 0
                       ? Math.Round(RealIncome / RealTurnover, 4, MidpointRounding.AwayFromZero)
                       : 0;
            }
        }

        public bool IsEmpty => RealTurnover == 0
                                && VirtualTurnover == 0
                                && MemberWinLoss == 0
                                && SMAWinLoss == 0
                                && RealIncome == 0
                                && VirtualIncome == 0;
    }
}