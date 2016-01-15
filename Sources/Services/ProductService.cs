using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Models.Main;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class ProductService : IProductService
    {
        private IRawWinLossService _rawWinLossService;

        private ICalculationService _calculationService;

        public ProductService(
            IRawWinLossService rawWinLossService,
            ICalculationService calculationService)
        {
            _rawWinLossService = rawWinLossService;
            _calculationService = calculationService;
        }

        public virtual MainWinLoss Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            return CalculateMainWinLoss(rawWinLosses);
        }

        public virtual MainWinLoss CalculateMainWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var rawSportsbookDetail = rawWinLosses.Where(r => r.Group == "Sportsbook Detail");
            var rawProductWinLoss = rawWinLosses.Where(r => r.Group != "Sportsbook Detail");

            var sportsbookDetail = CalculateSportsbookDetail(rawSportsbookDetail);
            var productWinLoss = _calculationService.CalculateGroupWinLoss(rawProductWinLoss);

            var grandTotal = _calculationService.CalculateGrandTotal(rawProductWinLoss);

            return new MainWinLoss
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
