using NAP.Reports.CompanyWinLoss.Models;
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
                Title = rawWinLoss.Site,
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

        public RawWinLoss CalculateSum(IEnumerable<RawWinLoss> winlosses)
        {
            var sumWinLoss = new RawWinLoss
            {
                Site = winlosses.First().Site,
                Group = winlosses.First().Group,
                IsLive = winlosses.First().IsLive,
                Commission = winlosses.Sum(r => r.Commission),
                MemberWinLoss = winlosses.Sum(r => r.MemberWinLoss),
                RealIncome = winlosses.Sum(r => r.RealIncome),
                VirtualIncome = winlosses.Sum(r => r.VirtualIncome),
                RealTurnover = winlosses.Sum(r => r.RealTurnover),
                SMAWinLoss = winlosses.Sum(r => r.SMAWinLoss),
                VirtualTurnover = winlosses.Sum(r => r.VirtualTurnover)
            };

            return sumWinLoss;
        }

        public IEnumerable<RawWinLoss> CalculateSum(IEnumerable<IEnumerable<RawWinLoss>> sources)
        {
            var count = sources.First().Count();
            for (var i = 0; i < count; i++)
            {
                var items = sources.Select(s => s.ElementAt(i));

                yield return CalculateSum(items);
            }
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

        public virtual IEnumerable<SiteWinLoss> CalculateGroupWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var groups = rawWinLosses.Select(r => r.Group).Distinct();
            foreach (var group in groups)
            {
                var productWinLoss = rawWinLosses.Where(r => r.Group == group).ToArray();
                var rawCreditWinLoss = productWinLoss.First(r => r.Site == "Credit");
                var rawDepositWinLoss = productWinLoss.First(r => r.Site == "Deposit");
                var creditWinLoss = FromRawWinLoss(rawCreditWinLoss);
                var depositWinLoss = FromRawWinLoss(rawDepositWinLoss);
                var totalWinLoss = CalculateTotal(group, creditWinLoss, depositWinLoss);

                yield return new SiteWinLoss
                {
                    Credit = creditWinLoss,
                    Deposit = depositWinLoss,
                    Total = totalWinLoss
                };
            }
        }

        public virtual SiteWinLoss CalculateGrandTotal(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var grandTotal = new SiteWinLoss
            {
                Credit = SumCreditGrandTotalWinLoss(rawWinLosses),
                Deposit = SumDepositGrandTotalWinLoss(rawWinLosses),
            };

            grandTotal.Total = CalculateTotal("Grand Total", grandTotal.Credit, grandTotal.Deposit);

            return grandTotal;
        }

        private WinLoss SumCreditGrandTotalWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var creditData = rawWinLosses.Where(r => r.Site == "Credit");
            var sumData = CalculateSum(creditData);

            return FromRawWinLoss(sumData);
        }

        private WinLoss SumDepositGrandTotalWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var depositData = rawWinLosses.Where(r => r.Site == "Deposit");
            var sumData = CalculateSum(depositData);

            return FromRawWinLoss(sumData);
        }
    }
}
