using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class CalculationService : ICalculationService
    {
        public WinLoss FromRawWinLoss(RawWinLoss rawWinLoss)
        {
            return new WinLoss
            {
                Title = rawWinLoss.Title,
                Commission = rawWinLoss.Commission,
                MemberWinLoss = rawWinLoss.MemberWinLoss,
                RealIncome = rawWinLoss.RealIncome,
                RealTurnover = rawWinLoss.RealTurnover,
                SMAWinLoss = rawWinLoss.SMAWinLoss,
                VirtualIncome = rawWinLoss.VirtualIncome,
                VirtualTurnover = rawWinLoss.VirtualTurnover,
                VarianceIncome = rawWinLoss.RealIncome - rawWinLoss.VirtualIncome,
                RealMargin = CalculateMargin(rawWinLoss.RealTurnover, rawWinLoss.RealIncome),
                VirtualMargin = CalculateMargin(rawWinLoss.VirtualTurnover, rawWinLoss.VirtualIncome)
            };
        }

        public decimal CalculateMargin(decimal turnover, decimal income)
        {
            return turnover > 0 ? income / turnover : 0;
        }

        public WinLoss CalculateTotal(RawWinLoss[] rawWinLosses, string totalTitle)
        {
            var rawTotalWinLoss = new RawWinLoss
            {
                Title = totalTitle,
                Commission = rawWinLosses.Sum(r => r.Commission),
                MemberWinLoss = rawWinLosses.Sum(r => r.MemberWinLoss),
                RealIncome = rawWinLosses.Sum(r => r.RealIncome),
                RealTurnover = rawWinLosses.Sum(r => r.RealTurnover),
                SMAWinLoss = rawWinLosses.Sum(r => r.SMAWinLoss),
                VirtualIncome = rawWinLosses.Sum(r => r.VirtualIncome),
                VirtualTurnover = rawWinLosses.Sum(r => r.VirtualTurnover)
            };

            return FromRawWinLoss(rawTotalWinLoss);
        }
    }
}
