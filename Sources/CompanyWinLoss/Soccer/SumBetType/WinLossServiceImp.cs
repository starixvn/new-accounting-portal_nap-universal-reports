using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Soccer.BetType;

namespace UniversalReports.CompanyWinLoss.Soccer.SumBetType
{
    public class WinLossServiceImp : WinLossService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public WinLossServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var betTypeWinLosses = calculationService.CalculateSiteWinLossSummary(rawWinLosses);
            var mainTotal = CalculateMainSumWinLossSummary("Main Bet Types Total", rawWinLosses);
            var otherTotal = CalculateOtherSumWinLossSummary("Other Bet Types Total", rawWinLosses);
            var grandTotal = calculationService.CalculateSumWinLossSummary("All Total", rawWinLosses);
            var allRMData = calculationService.CalculateRM(rawWinLosses);

            return new WinLossModel
            {
                SiteWinLossSummaries = betTypeWinLosses.ToList(),
                MainTotal = mainTotal,
                OtherTotal = otherTotal,
                GrandTotal = grandTotal,
                RM = allRMData.ToList()
            };
        }

        private WinLoss CalculateMainSumWinLossSummary(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var mainRawWinLosses = rawWinLosses.Where(r => Enum.IsDefined(typeof(GroupConstants.MainBetTypes), r.GroupId));
            var total = calculationService.CalculateSumWinLoss(sumTitle, mainRawWinLosses);

            return total;
        }

        private WinLoss CalculateOtherSumWinLossSummary(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var otherRawWinLosses = rawWinLosses.Where(r => !Enum.IsDefined(typeof(GroupConstants.MainBetTypes), r.GroupId));
            var total = calculationService.CalculateSumWinLoss(sumTitle, otherRawWinLosses);

            return total;
        }
    }
}
