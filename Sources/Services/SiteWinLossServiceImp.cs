using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class SiteWinLossServiceImp : SiteWinLossService
    {
        private RawWinLossService _rawWinLossService;

        private CalculationService _calculationService;

        public SiteWinLossServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            _rawWinLossService = rawWinLossService;
            _calculationService = calculationService;
        }

        public SiteWinLoss Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            var siteWinLosses = rawWinLosses.Select(r => _calculationService.FromRawWinLoss(r));
            var rawGrandTotal = _calculationService.CalculateSum(rawWinLosses);
            var grandTotal = _calculationService.FromRawWinLoss(rawGrandTotal);
            grandTotal.GroupName = "Total";

            return new SiteWinLoss
            {
                Sites = siteWinLosses.ToList(),
                Total = grandTotal
            };
        }
    }
}
