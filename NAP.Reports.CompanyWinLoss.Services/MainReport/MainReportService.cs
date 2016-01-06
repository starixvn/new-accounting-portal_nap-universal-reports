using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services.MainReport
{
    public class MainReportService : IMainReportService
    {
        private const string Sportsbook = "Sportsbook";
        private IProductWinLossService _productWinLossService;

        private ISportsbookWinLossService _sportsbookWinLossService;

        private ICalculationService _calculationService;

        private string[] _productNames;

        public MainReportService(
            ISportsbookWinLossService sportsbookWinLossService,
            IProductWinLossService productWinLossService,
            ICalculationService calculationService,
            params string[] productNames)
        {
            _productWinLossService = productWinLossService;
            _sportsbookWinLossService = sportsbookWinLossService;
            _calculationService = calculationService;

            _productNames = productNames;
        }

        public MainReportWinLoss Query(MainReportQuery query)
        {
            var sportsbookWinLossDetail = _sportsbookWinLossService.Query(query);
            var sportsbookWinLoss = _productWinLossService.Query(Sportsbook, query);
            var productWinlosses = _productNames.Select(p => _productWinLossService.Query(p, query)).ToList();

            var result = new MainReportWinLoss
            {
                SportsbookDetail = sportsbookWinLossDetail,
                Sportsbook = sportsbookWinLoss,
                OtherProducts = productWinlosses,
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
            var creditData = mainReportWinLoss.OtherProducts.Select(p => p.Credit).ToList();
            creditData.Add(mainReportWinLoss.Sportsbook.Credit);

            return _calculationService.CalculateSum("Credit", creditData);
        }

        private WinLoss SumDepositGrandTotalWinLoss(MainReportWinLoss mainReportWinLoss)
        {
            var depositData = mainReportWinLoss.OtherProducts.Select(p => p.Deposit).ToList();
            depositData.Add(mainReportWinLoss.Sportsbook.Deposit);

            return _calculationService.CalculateSum("Deposit", depositData);
        }

        private WinLoss SumGrandTotalWinLoss(MainReportWinLoss mainReportWinLoss)
        {
            var totalData = mainReportWinLoss.OtherProducts.Select(p => p.Total).ToList();
            totalData.Add(mainReportWinLoss.Sportsbook.Total);

            return _calculationService.CalculateSum("Grand Total", totalData);
        }
    }
}
