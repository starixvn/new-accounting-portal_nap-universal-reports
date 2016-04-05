using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class CalculationServiceImp : CalculationService
    {
        public WinLoss FromRawWinLossByRowName(RawWinLoss rawWinLoss)
        {
            var winloss = FromRawWinLoss(rawWinLoss);
            winloss.Name = rawWinLoss.RowName;
            return winloss;
        }

        public WinLoss FromRawWinLossByGroupName(RawWinLoss rawWinLoss)
        {
            var winloss = FromRawWinLoss(rawWinLoss);
            winloss.Name = rawWinLoss.GroupName;
            return winloss;
        }

        private WinLoss FromRawWinLoss(RawWinLoss rawWinLoss)
        {
            return new WinLoss
            {
                Id = rawWinLoss.GroupId,
                Commission = rawWinLoss.Commission,
                MemberWinLoss = rawWinLoss.MemberWinLoss,
                RealIncome = rawWinLoss.RealIncome,
                RealTurnover = rawWinLoss.RealTurnover,
                SMAWinLoss = rawWinLoss.SMAWinLoss,
                VirtualIncome = rawWinLoss.VirtualIncome,
                VirtualTurnover = rawWinLoss.VirtualTurnover,
                VarianceIncome = rawWinLoss.VarianceIncome,
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
            if (!winlosses.Any())
            {
                return new RawWinLoss();
            }

            return new RawWinLoss
            {
                GroupId = winlosses.First().GroupId,
                RowName = winlosses.First().RowName,
                GroupName = winlosses.First().GroupName,
                Commission = winlosses.Sum(r => r.Commission),
                MemberWinLoss = winlosses.Sum(r => r.MemberWinLoss),
                RealIncome = winlosses.Sum(r => r.RealIncome),
                VirtualIncome = winlosses.Sum(r => r.VirtualIncome),
                RealTurnover = winlosses.Sum(r => r.RealTurnover),
                SMAWinLoss = winlosses.Sum(r => r.SMAWinLoss),
                VirtualTurnover = winlosses.Sum(r => r.VirtualTurnover)
            };
        }

        public WinLoss CalculateSumWinLoss(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var totalRawWinLoss = CalculateSum(rawWinLosses);
            var totalWinLoss = FromRawWinLossByGroupName(totalRawWinLoss);
            totalWinLoss.Name = sumTitle;

            return totalWinLoss;
        }

        public virtual SiteWinLossSummary CalculateSumWinLossSummary(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var grandTotal = new SiteWinLossSummary
            {
                Credit = SumCreditGrandTotalWinLoss(rawWinLosses),
                Deposit = SumDepositGrandTotalWinLoss(rawWinLosses),
                Total = CalculateSumWinLoss(sumTitle, rawWinLosses)
            };

            return grandTotal;
        }

        private WinLoss SumCreditGrandTotalWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var creditData = rawWinLosses.Where(r => r.RowName == "Credit");
            var sumData = CalculateSum(creditData);

            var winloss = FromRawWinLossByRowName(sumData);
            winloss.Name = "Credit";

            return winloss;
        }

        private WinLoss SumDepositGrandTotalWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var depositData = rawWinLosses.Where(r => r.RowName == "Deposit");
            var sumData = CalculateSum(depositData);

            var winloss = FromRawWinLossByRowName(sumData);
            winloss.Name = "Deposit";

            return winloss;
        }

        public virtual IEnumerable<SiteWinLossSummary> CalculateSiteWinLossSummary(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var groups = rawWinLosses.Select(r => new { Name = r.GroupName, Id = r.GroupId }).Distinct();
            return from @group in groups
                   let rawGroupWinLosses = rawWinLosses.Where(r => r.GroupId == @group.Id && r.GroupName == @group.Name).ToArray()
                   select CalculateSiteWinLossSummary(@group.Id, @group.Name, rawGroupWinLosses);
        }

        public virtual SiteWinLossSummary CalculateSiteWinLossSummary(int groupId, string groupName, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var rawCreditWinLoss = rawWinLosses.FirstOrDefault(r => r.RowName == "Credit");
            var rawDepositWinLoss = rawWinLosses.FirstOrDefault(r => r.RowName == "Deposit");

            var creditWinLoss = rawCreditWinLoss == null ? CreateEmptyWinLoss(groupId, "Credit") : FromRawWinLossByRowName(rawCreditWinLoss);
            var depositWinLoss = rawDepositWinLoss == null ? CreateEmptyWinLoss(groupId, "Deposit") : FromRawWinLossByRowName(rawDepositWinLoss);
            var totalWinLoss = rawWinLosses.Any() ? CalculateSumWinLoss(groupName, rawWinLosses) : CreateEmptyWinLoss(groupId, groupName);

            return new SiteWinLossSummary
            {
                Credit = creditWinLoss,
                Deposit = depositWinLoss,
                Total = totalWinLoss
            };
        }

        public WinLoss CreateEmptyWinLoss(int id, string name)
        {
            return new WinLoss
            {
                Id = id,
                Name = name
            };
        }
    }
}