using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class ProductWinLossService : IProductWinLossService
    {
        private IRawWinLossService _rawWinLossService;

        private ICalculationService _calculationService;

        public ProductWinLossService(
            IRawWinLossService rawWinLossService,
            ICalculationService calculationService)
        {
            _rawWinLossService = rawWinLossService;
            _calculationService = calculationService;
        }

        public virtual ProductWinLoss Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            var rawSportsbookDetail = rawWinLosses.Where(r => r.GroupName == "Sportsbook Detail");
            var rawProductWinLoss = rawWinLosses.Where(r => r.GroupName != "Sportsbook Detail");

            var sportsbookDetail = CalculateSportsbookDetail(rawSportsbookDetail);
            var productWinLoss = _calculationService.CalculateSiteWinLossSummary(rawProductWinLoss);

            var grandTotal = _calculationService.CalculateGrandTotal("GRAND TOTAL", rawProductWinLoss);

            return new ProductWinLoss
            {
                GrandTotal = grandTotal,
                Products = productWinLoss.ToList(),
                SportsbookDetail = sportsbookDetail
            };
        }

        public virtual List<WinLoss> CalculateSportsbookDetail(IEnumerable<RawWinLoss> rawWinLosses)
        {
            return rawWinLosses.Select(r => _calculationService.FromRawWinLoss(r)).ToList();
        }
    }
}
