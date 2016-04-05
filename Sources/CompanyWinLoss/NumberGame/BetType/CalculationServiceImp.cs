using System.Collections.Generic;
using System.Linq;
using CommonModels = UniversalReports.CompanyWinLoss.Common.Models;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.NumberGame.BetType
{
    public class CalculationServiceImp : CalculationService
    {
        private readonly CommonServices.CalculationService caculationService;

        public CalculationServiceImp(CommonServices.CalculationService caculationService)
        {
            this.caculationService = caculationService;
        }

        public virtual IEnumerable<CommonModels.SiteWinLossSummary> CalculateSiteWinLossSummary(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var groups = rawWinLosses.Select(r => new { Name = r.GroupName, Id = r.GroupId }).Distinct();
            return from @group in groups
                   let rawGroupWinLosses = rawWinLosses.Where(r => r.GroupId == @group.Id && r.GroupName == @group.Name).ToArray()
                   select CalculateSiteWinLossSummary(@group.Id, @group.Name, rawGroupWinLosses);
        }

        public virtual CommonModels.SiteWinLossSummary CalculateSiteWinLossSummary(int groupId, string groupName, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var rawCreditWinLoss = rawWinLosses.FirstOrDefault(r => r.RowName == "Credit");
            var rawDepositWinLoss = rawWinLosses.FirstOrDefault(r => r.RowName == "Deposit");

            var creditWinLoss = rawCreditWinLoss == null
                ? caculationService.CreateEmptyWinLoss(groupId, "Credit")
                : FromRawWinLoss(rawCreditWinLoss);
            var depositWinLoss = rawDepositWinLoss == null
                ? caculationService.CreateEmptyWinLoss(groupId, "Deposit")
                : FromRawWinLoss(rawDepositWinLoss);
            var totalWinLoss = rawWinLosses.Any()
                ? CalculateSumWinLoss(groupName, rawWinLosses)
                : caculationService.CreateEmptyWinLoss(groupId, groupName);

            return new CommonModels.SiteWinLossSummary
            {
                Credit = creditWinLoss,
                Deposit = depositWinLoss,
                Total = totalWinLoss
            };
        }

        public CommonModels.WinLoss CalculateSumWinLoss(string totalTitle, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var totalRawWinLoss = CalculateSum(rawWinLosses);
            var totalWinLoss = FromRawWinLoss(totalRawWinLoss);
            totalWinLoss.Name = totalTitle;

            return totalWinLoss;
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

        public virtual CommonModels.SiteWinLossSummary CalculateSumWinLossSummary(string totalTile, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var grandTotal = new CommonModels.SiteWinLossSummary
            {
                Credit = SumCreditGrandTotalWinLoss(rawWinLosses),
                Deposit = SumDepositGrandTotalWinLoss(rawWinLosses),
                Total = CalculateSumWinLoss(totalTile, rawWinLosses)
            };

            return grandTotal;
        }

        private CommonModels.WinLoss SumCreditGrandTotalWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var creditData = rawWinLosses.Where(r => r.RowName == "Credit");
            var sumData = CalculateSum(creditData);

            return FromRawWinLoss(sumData);
        }

        private CommonModels.WinLoss SumDepositGrandTotalWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var depositData = rawWinLosses.Where(r => r.RowName == "Deposit");
            var sumData = CalculateSum(depositData);

            return FromRawWinLoss(sumData);
        }

        private CommonModels.WinLoss FromRawWinLoss(RawWinLoss rawWinLoss)
        {
            return new CommonModels.WinLoss
            {
                Id = rawWinLoss.GroupId,
                Name = rawWinLoss.RowName,
                Commission = rawWinLoss.Commission,
                MemberWinLoss = rawWinLoss.MemberWinLoss,
                RealIncome = rawWinLoss.RealIncome,
                RealTurnover = rawWinLoss.RealTurnover,
                SMAWinLoss = rawWinLoss.SMAWinLoss,
                VirtualIncome = rawWinLoss.VirtualIncome,
                VirtualTurnover = rawWinLoss.VirtualTurnover,
                VarianceIncome = rawWinLoss.VarianceIncome,
                RealMargin = caculationService.CalculateMargin(rawWinLoss.RealTurnover, rawWinLoss.RealIncome),
                VirtualMargin = caculationService.CalculateMargin(rawWinLoss.VirtualTurnover, rawWinLoss.VirtualIncome)
            };
        }
    }
}