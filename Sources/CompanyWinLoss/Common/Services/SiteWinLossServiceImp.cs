using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class SiteWinLossServiceImp : SiteWinLossService
    {
        private readonly RawWinLossService _rawWinLossService;

        private readonly CalculationService _calculationService;

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
