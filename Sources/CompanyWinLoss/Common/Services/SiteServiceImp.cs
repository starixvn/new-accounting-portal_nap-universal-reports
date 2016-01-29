using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class SiteServiceImp : SiteService
    {
        private readonly RawService _rawWinLossService;

        private readonly CalculationService _calculationService;

        public SiteServiceImp(
            RawService rawService,
            CalculationService calculationService)
        {
            _rawWinLossService = rawService;
            _calculationService = calculationService;
        }

        public SiteWinLoss Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            var siteWinLosses = rawWinLosses.Select(r => _calculationService.FromRawWinLoss(r));
            var grandTotal = _calculationService.CalculateSumWinLoss("Total", rawWinLosses);

            return new SiteWinLoss
            {
                Sites = siteWinLosses.ToList(),
                Total = grandTotal
            };
        }
    }
}
