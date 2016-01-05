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

        public MainReportSportsbookService(IDynamicRepository repository)
        {
            _repository = repository;
        }

        public SportsbookWinLoss Query(MainReportQuery query)
        {
            var criteria = new MainReportSportsbookCriteria { StartDate = query.StartDate, EndDate = query.EndDate };
            var rawSportsbookWinLoss = _repository.Query<RawWinLoss>(criteria).ToArray();

            return new SportsbookWinLoss
            {
                Products = CalculateSportsbookProducts(rawSportsbookWinLoss),
                Total = CalculateTotal(rawSportsbookWinLoss)
            };
        }

        private List<WinLoss> CalculateSportsbookProducts(RawWinLoss[] rawSportsbookWinLoss)
        {
            return rawSportsbookWinLoss.Select(r => FromRawWinLoss(r)).ToList();
        }

        private WinLoss FromRawWinLoss(RawWinLoss rawWinLoss)
        {
            return new WinLoss
            {
                Title = rawWinLoss.Title,
                Commission = rawWinLoss.Commission,
                MemberWinLoss = rawWinLoss.MemberWinLoss,
                RealIncome = rawWinLoss.RealIncome,
                RealTurnover = rawWinLoss.RealTurnover,
                SMAWinLoss = rawWinLoss.SMAWinLoss,
                VirtualIncome = rawWinLoss.VirtualIncome,
                VirtualTurnover = rawWinLoss.VirtualTurnover,
                VarianceIncome = rawWinLoss.RealIncome - rawWinLoss.VirtualIncome,
                RealMargin = CalculateMargin(rawWinLoss.RealTurnover, rawWinLoss.RealIncome),
                VirtualMargin = CalculateMargin(rawWinLoss.VirtualTurnover, rawWinLoss.VirtualIncome)
            };
        }

        private decimal CalculateMargin(decimal turnover, decimal income)
        {
            return turnover > 0 ? income / turnover : 0;
        }

        private WinLoss CalculateTotal(RawWinLoss[] rawSportsbookWinLoss)
        {
            var rawTotalWinLoss = new RawWinLoss
            {
                Title = "Sportsbook Total",
                Commission = rawSportsbookWinLoss.Sum(r => r.Commission),
                MemberWinLoss = rawSportsbookWinLoss.Sum(r => r.MemberWinLoss),
                RealIncome = rawSportsbookWinLoss.Sum(r => r.RealIncome),
                RealTurnover = rawSportsbookWinLoss.Sum(r => r.RealTurnover),
                SMAWinLoss = rawSportsbookWinLoss.Sum(r => r.SMAWinLoss),
                VirtualIncome = rawSportsbookWinLoss.Sum(r => r.VirtualIncome),
                VirtualTurnover = rawSportsbookWinLoss.Sum(r => r.VirtualTurnover)
            };

            return FromRawWinLoss(rawTotalWinLoss);
        }
    }
}
