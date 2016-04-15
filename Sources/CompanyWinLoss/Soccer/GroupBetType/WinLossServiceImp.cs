using System;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Soccer.GroupBetType
{
    public class WinLossServiceImp : WinLossService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly Common.Services.CalculationService calculationService;

        public WinLossServiceImp(
            RawWinLossService rawWinLossService,
            Common.Services.CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var betTypeWinLosses = CalculateSiteWinLossSummary(rawWinLosses);
            var mainTotal = CalculateMainSumWinLossSummary("Main Bet Types Total", rawWinLosses);
            var otherTotal = CalculateOtherSumWinLossSummary("Other Bet Types Total", rawWinLosses);
            var grandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", rawWinLosses);

            return new WinLossModel
            {
                SiteWinLossSummaries = betTypeWinLosses,
                MainTotal = mainTotal,
                OtherTotal = otherTotal,
                GrandTotal = grandTotal
            };
        }

        private List<WinLossSummaryByBetTypeGroup> CalculateSiteWinLossSummary(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var groups = rawWinLosses.Select(r => new { Name = r.GroupName, Id = r.GroupId }).Distinct();
            var winLosses = from @group in groups
                            let rawGroupWinLosses = rawWinLosses.Where(r => r.GroupId == @group.Id && r.GroupName == @group.Name).ToArray()
                            select calculationService.CalculateSiteWinLossSummary(@group.Id, @group.Name, rawGroupWinLosses);
            var winLossesByBetTypeGroup = CalculateSiteWinLossSummaryByBetTypeGroup(winLosses);

            return winLossesByBetTypeGroup;
        }

        private List<WinLossSummaryByBetTypeGroup> CalculateSiteWinLossSummaryByBetTypeGroup(IEnumerable<SiteWinLossSummary> winLosses)
        {
            var winLossesGroup1 = winLosses.Where(r => Enum.IsDefined(typeof(SoccerBetTypeGroupConstants.BetTypeGroup1), r.Total.Id));
            var winLossesGroup2 = winLosses.Where(r => Enum.IsDefined(typeof(SoccerBetTypeGroupConstants.BetTypeGroup2), r.Total.Id));
            var winLossesGroup3 = winLosses.Where(r => Enum.IsDefined(typeof(SoccerBetTypeGroupConstants.BetTypeGroup3), r.Total.Id));
            var winLossesGroup4 = winLosses.Where(r => !SoccerBetTypeGroupConstants.BetTypeGroup123().Contains(r.Total.Id));

            List<WinLossSummaryByBetTypeGroup> winLossesByGroupList = new List<WinLossSummaryByBetTypeGroup>();
            winLossesByGroupList = CreateWinLossByGroupList(winLossesByGroupList, winLossesGroup1);
            winLossesByGroupList = CreateWinLossByGroupList(winLossesByGroupList, winLossesGroup2);
            winLossesByGroupList = CreateWinLossByGroupList(winLossesByGroupList, winLossesGroup3);
            winLossesByGroupList = CreateWinLossByGroupList(winLossesByGroupList, winLossesGroup4);

            return winLossesByGroupList;
        }

        private List<WinLossSummaryByBetTypeGroup> CreateWinLossByGroupList(
            List<WinLossSummaryByBetTypeGroup> winLossesByGroupList,
            IEnumerable<SiteWinLossSummary> winLossesGroup)
        {
            if (winLossesGroup.Count() > 0)
            {
                winLossesByGroupList.Add(CreateWinLossSummaryByBetTypeGroup(winLossesGroup));
            }

            return winLossesByGroupList;
        }

        private WinLossSummaryByBetTypeGroup CreateWinLossSummaryByBetTypeGroup(IEnumerable<SiteWinLossSummary> winLossesGroup)
        {
            return new WinLossSummaryByBetTypeGroup
            {
                SiteWinLossSummaries = winLossesGroup.ToList(),
                Total = CalculateSumWinLoss("TOTAL", winLossesGroup.Select(r => r.Total))
            };
        }

        private WinLoss CalculateSumWinLoss(string sumTitle, IEnumerable<WinLoss> winLosses)
        {
            var totalWinLoss = CalculateSum(winLosses);
            totalWinLoss.Name = sumTitle;

            return totalWinLoss;
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
            winLossSum.RealMargin = calculationService.CalculateMargin(winLossSum.RealTurnover, winLossSum.RealIncome);
            winLossSum.VirtualMargin = calculationService.CalculateMargin(winLossSum.VirtualTurnover, winLossSum.VirtualIncome);

            return winLossSum;
        }

        public WinLoss CalculateMainSumWinLossSummary(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var mainRawWinLosses = rawWinLosses.Where(r => Enum.IsDefined(typeof(SoccerBetTypeGroupConstants.MainBetTypes), r.GroupId));
            var total = calculationService.CalculateSumWinLoss(sumTitle, mainRawWinLosses);

            return total;
        }

        public WinLoss CalculateOtherSumWinLossSummary(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var otherRawWinLosses = rawWinLosses.Where(r => !Enum.IsDefined(typeof(SoccerBetTypeGroupConstants.MainBetTypes), r.GroupId));
            var total = calculationService.CalculateSumWinLoss(sumTitle, otherRawWinLosses);

            return total;
        }
    }
}
