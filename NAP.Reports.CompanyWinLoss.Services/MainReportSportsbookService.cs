using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using System;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class MainReportSportsbookService : IMainReportSportsbookService
    {
        private IDynamicRepository _repository;

        public MainReportSportsbookService(IDynamicRepository repository)
        {
            _repository = repository;
        }

        public SportsbookWinLoss Query(MainReportQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
