using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAP.Reports.CompanyWinLoss.Services
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

        public virtual List<RawWinLoss> Query(WinLossCriteria criteria)
        {
            var sources = _balanceUpSourceChooser.Determine(criteria.StartDate, criteria.EndDate);
            var tasks = sources.Select(s => QueryBySourceAsync(s, criteria)).ToArray();
            Task.WaitAll(tasks);

            var winlossesBySources = tasks.Select(t => t.Result);
            return _calculationService.CalculateSum(winlossesBySources).ToList();
        }

        public virtual List<RawWinLoss> QueryBySource(BalanceUpSource source, WinLossCriteria criteria)
        {
            criteria.StartDate = source.StartDate;
            criteria.EndDate = source.EndDate;
            criteria.Source = source.Source;

            return _repository.Fetch<RawWinLoss>(criteria).ToList();
        }

        public async Task<List<RawWinLoss>> QueryBySourceAsync(BalanceUpSource source, WinLossCriteria criteria)
        {
            return await Task.Run(() => QueryBySource(source, criteria));
        }
    }
}
