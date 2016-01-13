using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAP.Reports.CompanyWinLoss.Services.MainReport
{
    public class MainReportService : IMainReportService
    {
        private IProductWinLossService _productWinLossService;

        private ISportsbookWinLossService _sportsbookWinLossService;

        private ICalculationService _calculationService;

        private IConfiguration _configuration;

        private List<string> _products;

        public MainReportService(
            ISportsbookWinLossService sportsbookWinLossService,
            IProductWinLossService productWinLossService,
            ICalculationService calculationService,
            IConfiguration configuration)
        {
            _productWinLossService = productWinLossService;
            _sportsbookWinLossService = sportsbookWinLossService;
            _calculationService = calculationService;
            _configuration = configuration;
            _products = configuration.Products;
        }

        public MainReportWinLoss Query(MainReportQuery query)
        {
            var sportsbookWinLossDetail = _sportsbookWinLossService.Query(query);
            var productWinLosses = _products.Select(p => _productWinLossService.Query(p, query)).ToList();

            return CalculateMainReportWinLoss(sportsbookWinLossDetail, productWinLosses);
        }

        private MainReportWinLoss CalculateMainReportWinLoss(List<WinLoss> sportsbookWinLossDetail, List<ProductWinLoss> products)
        {
            var result = new MainReportWinLoss
            {
                SportsbookDetail = sportsbookWinLossDetail,
                Products = products,
            };

            result.GrandTotal = CalculateGrandTotal(result);

            return result;
        }

        private ProductWinLoss CalculateGrandTotal(MainReportWinLoss mainReportWinLoss)
        {
            return new ProductWinLoss
            {
                Credit = SumCreditGrandTotalWinLoss(mainReportWinLoss),
                Deposit = SumDepositGrandTotalWinLoss(mainReportWinLoss),
                Total = SumGrandTotalWinLoss(mainReportWinLoss)
            };
        }

        private WinLoss SumCreditGrandTotalWinLoss(MainReportWinLoss mainReportWinLoss)
        {
            var creditData = mainReportWinLoss.Products.Select(p => p.Credit).ToList();

            return _calculationService.CalculateSum("Credit", creditData);
        }

        private WinLoss SumDepositGrandTotalWinLoss(MainReportWinLoss mainReportWinLoss)
        {
            var depositData = mainReportWinLoss.Products.Select(p => p.Deposit).ToList();

            return _calculationService.CalculateSum("Deposit", depositData);
        }

        private WinLoss SumGrandTotalWinLoss(MainReportWinLoss mainReportWinLoss)
        {
            var totalData = mainReportWinLoss.Products.Select(p => p.Total).ToList();

            return _calculationService.CalculateSum("Grand Total", totalData);
        }

        public async Task<MainReportWinLoss> QueryAsync(MainReportQuery query)
        {
            var sportsbookWinLossDetail = await _sportsbookWinLossService.QueryAsync(query);
            var tasks = _products.Select(p => _productWinLossService.QueryAsync(p, query));
            var productWinLosses = await Task.WhenAll(tasks);

            return CalculateMainReportWinLoss(sportsbookWinLossDetail, productWinLosses.ToList());
        }
    }
}
