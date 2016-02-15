using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class SportTypeServiceImp : SportTypeService
    {
        private readonly RawService _rawWinLossService;

        private readonly CalculationService _calculationService;

        public SportTypeServiceImp(
            RawService rawService,
            CalculationService calculationService)
        {
            _rawWinLossService = rawService;
            _calculationService = calculationService;
        }

        public SportTypeWinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            var sports = _calculationService.CalculateSiteWinLossSummary(rawWinLosses);
            var grandTotal = _calculationService.CalculateSumWinLossSummary("Grand Total", rawWinLosses);

            return new SportTypeWinLossModel
            {
                Sports = sports.ToList(),
                GrandTotal = grandTotal
            };
        }
    }
}
