using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class BetTypeServiceImp : BetTypeService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public BetTypeServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public BetTypeWinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var betTypeWinLosses = calculationService.CalculateSiteWinLossSummary(rawWinLosses);
            var grandTotal = calculationService.CalculateSumWinLossSummary("All Total", rawWinLosses);

            return new BetTypeWinLossModel
            {
                BetTypes = betTypeWinLosses.ToList(),
                GrandTotal = grandTotal
            };
        }
    }
}