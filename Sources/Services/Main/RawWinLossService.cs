using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.QueryModels.Main;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAP.Reports.CompanyWinLoss.Services.Main
{
    public class RawWinLossService : IRawWinLossService
    {
        private IDynamicRepository _repository;

        private ICalculationService _calculationService;

        private IBalanceUpSourceChooser _balanceUpSourceChooser;

        public RawWinLossService(IDynamicRepository repository, ICalculationService calculationService, IBalanceUpSourceChooser balanceUpSourceChooser)
        {
            _repository = repository;
            _calculationService = calculationService;
            _balanceUpSourceChooser = balanceUpSourceChooser;
        }

        public virtual List<RawWinLoss> Query(MainQuery query)
        {
            var sources = _balanceUpSourceChooser.Determine(query.StartDate, query.EndDate);
            var tasks = sources.Select(s => QueryBySourceAsync(s)).ToArray();
            Task.WaitAll(tasks);

            var winlossesBySources = tasks.Select(t => t.Result);
            return _calculationService.CalculateSum(winlossesBySources).ToList();
        }

        public virtual List<RawWinLoss> QueryBySource(BalanceUpSource source)
        {
            var criteria = new WinLossCriteria
            {
                StartDate = source.StartDate,
                EndDate = source.EndDate,
                Source = source.Source,
            };

            return _repository.Fetch<RawWinLoss>(criteria).ToList();
        }

        public async Task<List<RawWinLoss>> QueryBySourceAsync(BalanceUpSource source)
        {
            return await Task.Run(() => QueryBySource(source));
        }
    }
}
