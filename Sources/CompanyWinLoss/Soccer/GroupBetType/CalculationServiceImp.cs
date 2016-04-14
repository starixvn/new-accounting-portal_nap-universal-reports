using System;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Soccer.GroupBetType
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
                ExtraPT = rawWinLoss.ExtraPT,
                AfterExtraPT = rawWinLoss.AfterExtraPT,
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
                VarianceIncome = winlosses.Sum(r => r.VarianceIncome),
                ExtraPT = winlosses.Sum(r => r.ExtraPT),
                AfterExtraPT = winlosses.Sum(r => r.AfterExtraPT),
                RealTurnover = winlosses.Sum(r => r.RealTurnover),
                SMAWinLoss = winlosses.Sum(r => r.SMAWinLoss),
                VirtualTurnover = winlosses.Sum(r => r.VirtualTurnover)
            };
        }

        private WinLoss CalculateSum(IEnumerable<WinLoss> winLosses)
        {
            if (!winLosses.Any())
            {
                return new WinLoss();
            }

            var winLossSum = new WinLoss
            {
                Commission = winLosses.Sum(r => r.Commission),
                MemberWinLoss = winLosses.Sum(r => r.MemberWinLoss),
                RealIncome = winLosses.Sum(r => r.RealIncome),
                RealTurnover = winLosses.Sum(r => r.RealTurnover),
                SMAWinLoss = winLosses.Sum(r => r.SMAWinLoss),
                VirtualIncome = winLosses.Sum(r => r.VirtualIncome),
                VirtualTurnover = winLosses.Sum(r => r.VirtualTurnover),
                VarianceIncome = winLosses.Sum(r => r.VarianceIncome),
                ExtraPT = winLosses.Sum(r => r.ExtraPT),
                AfterExtraPT = winLosses.Sum(r => r.AfterExtraPT)
            };
            winLossSum.RealMargin = CalculateMargin(winLossSum.RealTurnover, winLossSum.RealIncome);
            winLossSum.VirtualMargin = CalculateMargin(winLossSum.VirtualTurnover, winLossSum.VirtualIncome);

            return winLossSum;
        }

        public WinLoss CalculateSumWinLoss(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var totalRawWinLoss = CalculateSum(rawWinLosses);
            var totalWinLoss = FromRawWinLossByGroupName(totalRawWinLoss);
            totalWinLoss.Name = sumTitle;

            return totalWinLoss;
        }

        private WinLoss CalculateSumWinLoss(string sumTitle, IEnumerable<WinLoss> winLosses)
        {
            var totalWinLoss = CalculateSum(winLosses);
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

        public WinLoss CalculateMainSumWinLossSummary(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var mainRawWinLosses = rawWinLosses.Where(r => Enum.IsDefined(typeof(SoccerBetTypeGroupConstants.MainBetTypes), r.GroupId));
            var total = CalculateSumWinLoss(sumTitle, mainRawWinLosses);
            
            return total;
        }

        public WinLoss CalculateOtherSumWinLossSummary(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var otherRawWinLosses = rawWinLosses.Where(r => !Enum.IsDefined(typeof(SoccerBetTypeGroupConstants.MainBetTypes), r.GroupId));
            var total = CalculateSumWinLoss(sumTitle, otherRawWinLosses);

            return total;
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

        public virtual IEnumerable<WinLossSummaryByBetTypeGroup> CalculateSiteWinLossSummary(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var groups = rawWinLosses.Select(r => new { Name = r.GroupName, Id = r.GroupId }).Distinct();
            var winLosses = from @group in groups
                   let rawGroupWinLosses = rawWinLosses.Where(r => r.GroupId == @group.Id && r.GroupName == @group.Name).ToArray()
                   select CalculateSiteWinLossSummary(@group.Id, @group.Name, rawGroupWinLosses);
            var winLossesByBetTypeGroup = CalculateSiteWinLossSummaryByBetTypeGroup(winLosses);

            return winLossesByBetTypeGroup;
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

        private IEnumerable<WinLossSummaryByBetTypeGroup> CalculateSiteWinLossSummaryByBetTypeGroup(IEnumerable<SiteWinLossSummary> winLosses)
        {
            var winLossesGroup1 = winLosses.Where(r => Enum.IsDefined(typeof(SoccerBetTypeGroupConstants.BetTypeGroup1), r.Total.Id));
            var winLossesGroup2 = winLosses.Where(r => Enum.IsDefined(typeof(SoccerBetTypeGroupConstants.BetTypeGroup2), r.Total.Id));
            var winLossesGroup3 = winLosses.Where(r => Enum.IsDefined(typeof(SoccerBetTypeGroupConstants.BetTypeGroup3), r.Total.Id));
            var winLossesGroup4 = winLosses.Where(r => !SoccerBetTypeGroupConstants.BetTypeGroup123().Contains(r.Total.Id));

            IEnumerable<WinLossSummaryByBetTypeGroup> winLossesByGroup = new List<WinLossSummaryByBetTypeGroup>
            {
                CreateWinLossSummaryByBetTypeGroup(winLossesGroup1),
                CreateWinLossSummaryByBetTypeGroup(winLossesGroup2),
                CreateWinLossSummaryByBetTypeGroup(winLossesGroup3),
                CreateWinLossSummaryByBetTypeGroup(winLossesGroup4)                
            };

            return winLossesByGroup;
        }

        private WinLossSummaryByBetTypeGroup CreateWinLossSummaryByBetTypeGroup(IEnumerable<SiteWinLossSummary> winLossesGroup)
        {
            return new WinLossSummaryByBetTypeGroup
            {
                SiteWinLossSummaries = winLossesGroup.ToList(),
                Total = CalculateSumWinLoss("TOTAL", winLossesGroup.Select(r => r.Total))
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
