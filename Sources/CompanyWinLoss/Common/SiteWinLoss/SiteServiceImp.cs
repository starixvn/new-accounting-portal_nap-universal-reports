using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Common.SiteWinLoss
{
    public class SiteServiceImp : SiteService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public SiteServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public SiteWinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var siteWinLosses = rawWinLosses.Select(r => calculationService.FromRawWinLossByRowName(r));
            var grandTotal = calculationService.CalculateSumWinLoss("Total", rawWinLosses);

            return new SiteWinLossModel
            {
                Sites = siteWinLosses.ToList(),
                Total = grandTotal
            };
        }
    }
}