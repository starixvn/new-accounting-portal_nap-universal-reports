using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class SportTypeServiceImp : SportTypeService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public SportTypeServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public SportTypeWinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var sports = calculationService.CalculateSiteWinLossSummary(rawWinLosses);
            var grandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", rawWinLosses);

            return new SportTypeWinLossModel
            {
                Sports = sports.ToList(),
                GrandTotal = grandTotal
            };
        }
    }
}