using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAP.Reports.CompanyWinLoss.Services.MainReport
{
    public class SportsbookWinLossService : ISportsbookWinLossService
    {
        private IDynamicRepository _repository;

        private ICalculationService _calculationService;

        private IBalanceUpSourceChooser _balanceUpSourceChooser;

        public SportsbookWinLossService(IDynamicRepository repository, ICalculationService calculationService, IBalanceUpSourceChooser balanceUpSourceChooser)
        {
            _repository = repository;
            _calculationService = calculationService;
            _balanceUpSourceChooser = balanceUpSourceChooser;
        }

        public List<WinLoss> Query(MainReportQuery query)
        {
            var sources = _balanceUpSourceChooser.Determine(query.StartDate, query.EndDate);
            var winlossesBySources = sources.Select(s => QueryBySource(s)).ToArray();

            return _calculationService.CalculateSum(winlossesBySources).ToList();
        }

        public List<WinLoss> QueryBySource(BalanceUpSource source)
        {
            var criteria = new SportsbookWinLossDetailCriteria
            {
                StartDate = source.StartDate,
                EndDate = source.EndDate,
                Source = source.Source
            };

            var rawWinLosses = _repository.Fetch<RawWinLoss>(criteria).ToArray();

            return rawWinLosses.Select(r => _calculationService.FromRawWinLoss(r))
                              .ToList();
        }

        public async Task<List<WinLoss>> QueryAsync(MainReportQuery query)
        {
            var sources = _balanceUpSourceChooser.Determine(query.StartDate, query.EndDate);
            var tasks = sources.Select(s => QueryBySourceAsync(s));
            var winlossesBySources = await Task.WhenAll(tasks);

            return _calculationService.CalculateSum(winlossesBySources).ToList();
        }

        public async Task<List<WinLoss>> QueryBySourceAsync(BalanceUpSource source)
        {
            return await Task.Run(() => QueryBySource(source));
        }
    }
}
