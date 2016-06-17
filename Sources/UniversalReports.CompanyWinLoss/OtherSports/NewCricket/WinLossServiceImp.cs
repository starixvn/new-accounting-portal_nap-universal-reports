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

        public WinLossServiceImp(RawWinLossService rawWinLossService, CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var rawWinLossChargedCom = CalculateSiteWinLossChargedCom(rawWinLosses);
            var siteWinLossNonChargedCom = CalculateSiteWinLossNonChargedCom(rawWinLosses);
            var grandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", rawWinLosses);
            var allRMData = calculationService.CalculateRM(rawWinLosses);

            return new WinLossModel
            {
                GrandTotal = grandTotal,
                RM = allRMData.ToList(),
                SiteWinLossChargedCom = CalculationChargedCommission(rawWinLosses, rawWinLossChargedCom),
                SiteWinLossNonChargedCom = siteWinLossNonChargedCom.OrderBy(s => s.Total.Name).ToList()
            };
        }

        public virtual IEnumerable<SiteWinLossSummary> CalculateSiteWinLossChargedCom(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var groups = rawWinLosses
                            .Where(r => r.GroupName != "RM" && r.GroupId == 500)
                            .Select(r => new { Name = r.GroupName, Id = r.GroupId })
                            .Distinct();
            return from @group in groups
                   let rawGroupWinLosses = rawWinLosses.Where(r => r.GroupId == @group.Id && r.GroupName == @group.Name).ToArray()
                   select calculationService.CalculateSiteWinLossSummary(@group.Id, @group.Name, rawGroupWinLosses);
        }

        public virtual IEnumerable<SiteWinLossSummary> CalculateSiteWinLossNonChargedCom(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var groups = rawWinLosses
                            .Where(r => r.GroupName != "RM" && r.GroupId != 500)
                            .Select(r => new { Name = r.GroupName, Id = r.GroupId })
                            .Distinct();
            return from @group in groups
                   let rawGroupWinLosses = rawWinLosses.Where(r => r.GroupId == @group.Id && r.GroupName == @group.Name).ToArray()
                   select calculationService.CalculateSiteWinLossSummary(@group.Id, @group.Name, rawGroupWinLosses);
        }

        public ChargeCommissionModel CalculationChargedCommission(IEnumerable<RawWinLoss> rawWinLosses, IEnumerable<SiteWinLossSummary> chargedCommision)
        {
            return new ChargeCommissionModel
            {
                Total = calculationService.CalculateChargedCommision("Total", rawWinLosses),
                Winloss = chargedCommision.OrderBy(s => s.Total.Name).ToList()
            };
        }
    }
}
