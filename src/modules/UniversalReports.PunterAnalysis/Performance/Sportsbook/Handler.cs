using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fanex.Data.Repository;
using MediatR;
using UniversalReports.PunterAnalysis.Performance.Sportsbook.Criteria;
using UniversalReports.PunterAnalysis.Performance.Sportsbook.Model;

namespace UniversalReports.PunterAnalysis.Performance.Sportsbook
{
    public class Handler : IAsyncRequestHandler<SportsbookHttpParameterJson, ViewModelJson>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ViewModelJson> Handle(SportsbookHttpParameterJson message)
        {
            var viewModel = new ViewModelJson();
            viewModel.SportStatistics = await Query<SportStatistic, SportCriteria>(message).ConfigureAwait(false);
            viewModel.SummaryStatistic = QuerySummaryStatistics(viewModel.SportStatistics);
            return viewModel;
        }

        private SummaryStatistic QuerySummaryStatistics(List<SportStatistic> sportStatistics)
        {
            return new SummaryStatistic
            {
                BetCount = sportStatistics.Sum(m => m.BetCount),
                Turnover = sportStatistics.Sum(m => m.Turnover),
                WinLoss = sportStatistics.Sum(m => m.WinLoss),
            };
        }

        private async Task<List<TResult>> Query<TResult, TCriteria>(SportsbookHttpParameterJson message) where TCriteria : ICriteria
        {
            var criteria = Mapper.Map<TCriteria>(message);
            var entities = await repository.FetchAsync<TResult>(criteria).ConfigureAwait(false);
            return entities.ToList();
        }
    }
}