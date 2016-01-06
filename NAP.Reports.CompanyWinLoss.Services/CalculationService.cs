using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
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

        public WinLoss CalculateTotal(string totalTitle, WinLoss credit, WinLoss deposit)
        {
            var totalWinLoss = new WinLoss
            {
                Title = totalTitle,
                Commission = credit.Commission + deposit.Commission,
                MemberWinLoss = credit.MemberWinLoss + deposit.MemberWinLoss,
                RealIncome = credit.RealIncome + deposit.RealIncome,
                VirtualIncome = credit.VirtualIncome + deposit.VirtualIncome,
                VarianceIncome = credit.VarianceIncome + deposit.VarianceIncome,
                RealTurnover = credit.RealTurnover + deposit.RealTurnover,
                SMAWinLoss = credit.SMAWinLoss + deposit.SMAWinLoss,
                VirtualTurnover = credit.VirtualTurnover + deposit.VirtualTurnover
            };

            totalWinLoss.VirtualMargin = CalculateMargin(totalWinLoss.VirtualTurnover, totalWinLoss.VirtualIncome);
            totalWinLoss.RealMargin = CalculateMargin(totalWinLoss.RealTurnover, totalWinLoss.RealIncome);

            return totalWinLoss;
        }

        public WinLoss CalculateSum(string totalTitle, IEnumerable<WinLoss> winlosses)
        {
            var sumWinLoss = new WinLoss
            {
                Title = totalTitle,
                Commission = winlosses.Sum(r => r.Commission),
                MemberWinLoss = winlosses.Sum(r => r.MemberWinLoss),
                RealIncome = winlosses.Sum(r => r.RealIncome),
                VirtualIncome = winlosses.Sum(r => r.VirtualIncome),
                VarianceIncome = winlosses.Sum(r => r.VarianceIncome),
                RealTurnover = winlosses.Sum(r => r.RealTurnover),
                SMAWinLoss = winlosses.Sum(r => r.SMAWinLoss),
                VirtualTurnover = winlosses.Sum(r => r.VirtualTurnover)
            };

            sumWinLoss.VirtualMargin = CalculateMargin(sumWinLoss.VirtualTurnover, sumWinLoss.VirtualIncome);
            sumWinLoss.RealMargin = CalculateMargin(sumWinLoss.RealTurnover, sumWinLoss.RealIncome);

            return sumWinLoss;
        }

        public WinLoss CreateEmptyWinLoss(string title)
        {
            return new WinLoss
            {
                Title = title,
                Commission = 0,
                MemberWinLoss = 0,
                RealIncome = 0,
                RealTurnover = 0,
                SMAWinLoss = 0,
                VirtualIncome = 0,
                VirtualTurnover = 0,
                VarianceIncome = 0,
                RealMargin = 0,
                VirtualMargin = 0,
            };
        }
    }
}
