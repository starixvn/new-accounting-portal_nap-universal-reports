using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class MainReportSportsbookService : IMainReportSportsbookService
    {
        private IDynamicRepository _repository;

        private ICalculationService _calculationService;

        public MainReportSportsbookService(IDynamicRepository repository, ICalculationService calculationService)
        {
            _repository = repository;
            _calculationService = calculationService;
        }

        public ProductWinLoss Query(MainReportQuery query)
        {
            var criteria = new MainReportSportsbookCriteria { StartDate = query.StartDate, EndDate = query.EndDate };
            var rawSportsbookWinLoss = _repository.Query<RawWinLoss>(criteria).ToArray();

            return new ProductWinLoss
            {
                Products = CalculateSportsbookProducts(rawSportsbookWinLoss),
                Total = _calculationService.CalculateTotal(rawSportsbookWinLoss, "Sportsbook Total")
            };
        }

        private List<WinLoss> CalculateSportsbookProducts(RawWinLoss[] rawSportsbookWinLoss)
        {
            return rawSportsbookWinLoss.Select(r => _calculationService.FromRawWinLoss(r)).ToList();
        }
    }
}
