using System.Linq;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.Common.SiteWinLoss
{
    public interface WinLossService
    {
        SiteWinLossModel Query(WinLossCriteria criteria);
    }

    public class WinLossServiceImp : WinLossService
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public WinLossServiceImp(
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
            var grandTotal = calculationService.CalculateSumWinLoss("Grand Total", rawWinLosses);

            return new SiteWinLossModel
            {
                Sites = siteWinLosses.ToList(),
                Total = grandTotal
            };
        }
    }
}