using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class BetTypeServiceImp : BetTypeService
    {
        private readonly RawService _rawWinLossService;

        private readonly CalculationService _calculationService;

        public BetTypeServiceImp(
            RawService rawService,
            CalculationService calculationService)
        {
            _rawWinLossService = rawService;
            _calculationService = calculationService;
        }

        public BetTypeWinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            var betTypeWinLosses = _calculationService.CalculateSiteWinLossSummary(rawWinLosses);
            var grandTotal = _calculationService.CalculateSumWinLossSummary("All Total", rawWinLosses);

            return new BetTypeWinLossModel
            {
                BetTypes = betTypeWinLosses.ToList(),
                GrandTotal = grandTotal
            };
        }
    }
}
