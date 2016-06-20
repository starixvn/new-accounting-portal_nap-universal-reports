using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.OtherSports.NewCricket
{
    public class WinLossServiceImp : WinLossService
    {
        private readonly RawWinLossService rawWinLossService;
        private readonly CalculationService calculationService;
        private int betTypeChargedCom = 500;

        public WinLossServiceImp(RawWinLossService rawWinLossService, CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);
            var rawWinLossFilter = rawWinLosses.GroupBy(item => item.GroupId == betTypeChargedCom).ToList();
            var winLossChargedCom = calculationService.CalculateSiteWinLossSummary(rawWinLossFilter.First());
            var siteWinLossNonChargedCom = calculationService.CalculateSiteWinLossSummary(rawWinLossFilter.Last());
            var grandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", rawWinLosses);

            return new WinLossModel
            {
                GrandTotal = grandTotal,
                RM = calculationService.CalculateRM(rawWinLosses).ToList(),
                SiteWinLossChargedCom = CalculateSiteChargedCom(rawWinLosses, winLossChargedCom),
                SiteWinLossNonChargedCom = siteWinLossNonChargedCom.OrderBy(s => s.Total.Name).ToList()
            };
        }

        public ChargeCommissionModel CalculateSiteChargedCom(IEnumerable<RawWinLoss> rawWinLosses, IEnumerable<SiteWinLossSummary> chargedCommision)
        {
            return new ChargeCommissionModel
            {
                Total = calculationService.CalculateSiteChargedCom("Total", rawWinLosses),
                Winloss = chargedCommision.OrderBy(s => s.Total.Name).ToList()
            };
        }
    }
}
