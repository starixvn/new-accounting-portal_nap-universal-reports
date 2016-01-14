using NAP.Reports.CompanyWinLoss.Models.Main;
using NAP.Reports.CompanyWinLoss.QueryModels.Main;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services.Main
{
    public class MainService : IMainService
    {
        private IRawWinLossService _rawWinLossService;

        private ICalculationService _calculationService;

        public MainService(
            IRawWinLossService rawWinLossService,
            ICalculationService calculationService)
        {
            _rawWinLossService = rawWinLossService;
            _calculationService = calculationService;
        }

        public virtual MainWinLoss Query(MainQuery query)
        {
            var rawWinLosses = _rawWinLossService.Query(query);

            return CalculateMainWinLoss(rawWinLosses);
        }

        public virtual MainWinLoss CalculateMainWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var rawSportsbookDetail = rawWinLosses.Where(r => r.Product == "Sportsbook Detail");
            var rawProductWinLoss = rawWinLosses.Where(r => r.Product != "Sportsbook Detail");

            var sportsbookDetail = CalculateSportsbookDetail(rawSportsbookDetail);
            var productWinLoss = CalculateProductWinLoss(rawProductWinLoss);

            var grandTotal = CalculateGrandTotal(rawProductWinLoss);

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

        public virtual IEnumerable<ProductWinLoss> CalculateProductWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var products = rawWinLosses.Select(r => r.Product).Distinct();
            foreach (var product in products)
            {
                var productWinLoss = rawWinLosses.Where(r => r.Product == product).ToArray();
                var rawCreditWinLoss = productWinLoss.First(r => r.Site == "Credit");
                var rawDepositWinLoss = productWinLoss.First(r => r.Site == "Deposit");
                var creditWinLoss = _calculationService.FromRawWinLoss(rawCreditWinLoss);
                var depositWinLoss = _calculationService.FromRawWinLoss(rawDepositWinLoss);
                var totalWinLoss = _calculationService.CalculateTotal(product, creditWinLoss, depositWinLoss);

                yield return new ProductWinLoss
                {
                    Credit = creditWinLoss,
                    Deposit = depositWinLoss,
                    Total = totalWinLoss
                };
            }
        }

        public virtual ProductWinLoss CalculateGrandTotal(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var grandTotal = new ProductWinLoss
            {
                Credit = SumCreditGrandTotalWinLoss(rawWinLosses),
                Deposit = SumDepositGrandTotalWinLoss(rawWinLosses),
            };

            grandTotal.Total = _calculationService.CalculateTotal("Grand Total", grandTotal.Credit, grandTotal.Deposit);

            return grandTotal;
        }

        private WinLoss SumCreditGrandTotalWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var creditData = rawWinLosses.Where(r => r.Site == "Credit");
            var sumData = _calculationService.CalculateSum(creditData);

            return _calculationService.FromRawWinLoss(sumData);
        }

        private WinLoss SumDepositGrandTotalWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            var depositData = rawWinLosses.Where(r => r.Site == "Deposit");
            var sumData = _calculationService.CalculateSum(depositData);

            return _calculationService.FromRawWinLoss(sumData);
        }
    }
}
