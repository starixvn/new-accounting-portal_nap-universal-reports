using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services.MainReport
{
    public class ProductWinLossService : IProductWinLossService
    {
        private IDynamicRepository _repository;

        private ICalculationService _calculationService;

        private IBalanceUpSourceChooser _balanceUpSourceChooser;

        public ProductWinLossService(IDynamicRepository repository, ICalculationService calculationService, IBalanceUpSourceChooser balanceUpSourceChooser)
        {
            _repository = repository;
            _calculationService = calculationService;
            _balanceUpSourceChooser = balanceUpSourceChooser;
        }

        public ProductWinLoss Query(string productName, MainReportQuery query)
        {
            var sources = _balanceUpSourceChooser.Determine(query.StartDate, query.EndDate);
            var winlossesBySources = sources.Select(s => QueryBySource(productName, s)).ToArray();
            var creditWinLossesBySources = winlossesBySources.Select(w => w.Credit);
            var depositWinLossesBySources = winlossesBySources.Select(w => w.Deposit);

            var creditWinLoss = _calculationService.CalculateSum("Credit", creditWinLossesBySources);
            var depositWinLoss = _calculationService.CalculateSum("Deposit", depositWinLossesBySources);
            var totalWinLoss = _calculationService.CalculateTotal(productName, creditWinLoss, depositWinLoss);

            return new ProductWinLoss
            {
                Credit = creditWinLoss,
                Deposit = depositWinLoss,
                Total = totalWinLoss
            };
        }

        public ProductWinLoss QueryBySource(string productName, BalanceUpSource source)
        {
            var criteria = new ProductWinLossCriteria
            {
                StartDate = source.StartDate,
                EndDate = source.EndDate,
                Source = source.Source,
                ProductName = productName,
            };

            var rawWinLosses = _repository.Query<RawWinLoss>(criteria).ToArray();
            var creditWinLoss = CalculateSiteWinLoss("Credit", rawWinLosses);
            var depositWinLoss = CalculateSiteWinLoss("Deposit", rawWinLosses);

            return new ProductWinLoss
            {
                Credit = creditWinLoss,
                Deposit = depositWinLoss,
                Total = _calculationService.CalculateTotal(productName, creditWinLoss, depositWinLoss)
            };
        }

        private WinLoss CalculateSiteWinLoss(string title, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var rawSiteWinLosses = rawWinLosses.FirstOrDefault(r => r.Title == title);
            return rawSiteWinLosses == null
                                    ? _calculationService.CreateEmptyWinLoss(title)
                                    : _calculationService.FromRawWinLoss(rawSiteWinLosses);
        }
    }
}
