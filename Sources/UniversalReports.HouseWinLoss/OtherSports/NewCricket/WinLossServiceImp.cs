using System.Collections.Generic;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.OtherSports.NewCricket
{
    public class WinLossServiceImp : WinLossService
    {
        private const int BetTypeChargedCom = 500;
        private readonly RawWinLossService rawWinLossService;
        private readonly CalculationService calculationService;

        public WinLossServiceImp(RawWinLossService rawWinLossService, CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var rawWinLossChargedCom = from r in rawWinLosses
                                       where r.GroupId == BetTypeChargedCom
                                       select r;
            var rawWinLossNonChargedCom = from r in rawWinLosses
                                          where r.GroupId != BetTypeChargedCom
                                          select r;
            var winLossChargedCom = calculationService.CalculateSiteWinLossSummary(rawWinLossChargedCom);
            var siteWinLossNonChargedCom = calculationService.CalculateSiteWinLossSummary(rawWinLossNonChargedCom);
            var grandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", rawWinLosses);

            return new WinLossModel
            {
                GrandTotal = grandTotal,
                RM = calculationService.CalculateRM(rawWinLosses).ToList(),
                SiteWinLossChargedCom = CalculateSiteChargedCom(rawWinLosses, winLossChargedCom),
                SiteWinLossNonChargedCom = siteWinLossNonChargedCom.OrderBy(s => s.Total.Name).ToList()
            };
        }

        public ChargeCommissionModel CalculateSiteChargedCom(IEnumerable<WinLossRaw> rawWinLosses, IEnumerable<SiteWinLossSummary> chargedCommision)
        {
            return new ChargeCommissionModel
            {
                Total = calculationService.CalculateSiteChargedCom("Total", rawWinLosses),
                Winloss = chargedCommision.OrderBy(s => s.Total.Name).ToList()
            };
        }
    }
}