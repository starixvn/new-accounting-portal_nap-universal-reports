using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class ReportWinLossServiceImp : ReportWinLossService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public ReportWinLossServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public ReportWinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var betTypeWinLosses = calculationService.CalculateSiteWinLossSummary(rawWinLosses);
            var grandTotal = calculationService.CalculateSumWinLossSummary("All Total", rawWinLosses);

            return new ReportWinLossModel
            {
                SiteWinLossSummaries = betTypeWinLosses.ToList(),
                GrandTotal = grandTotal
            };
        }
    }
}