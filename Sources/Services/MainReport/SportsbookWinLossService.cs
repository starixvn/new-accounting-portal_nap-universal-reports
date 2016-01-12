using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services.MainReport
{
    public class SportsbookWinLossService : ISportsbookWinLossService
    {
        private IDynamicRepository _repository;

        private ICalculationService _calculationService;

        public SportsbookWinLossService(IDynamicRepository repository, ICalculationService calculationService)
        {
            _repository = repository;
            _calculationService = calculationService;
        }

        public List<WinLoss> Query(MainReportQuery query)
        {
            var criteria = new SportsbookWinLossDetailCriteria
            {
                StartDate = query.StartDate,
                EndDate = query.EndDate
            };
            var rawWinLosses = _repository.Query<RawWinLoss>(criteria).ToArray();

            return rawWinLosses.Select(r => _calculationService.FromRawWinLoss(r))
                              .ToList();
        }
    }
}
