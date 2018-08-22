using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Fanex.Data.Repository;
using MediatR;
using UniversalReports.PunterAnalysis.Performance.Summary.Criteria;
using UniversalReports.PunterAnalysis.Performance.Summary.Model;

namespace UniversalReports.PunterAnalysis.Performance.Summary
{
    public class Handler : IRequestHandler<SummaryHttpParameterJson, ViewModelJson>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ViewModelJson> Handle(SummaryHttpParameterJson request, CancellationToken cancellationToken)
        {
            var viewModel = new ViewModelJson();

            viewModel.MonthStatistics = await Query<MonthStatistic, MonthCriteria>(request).ConfigureAwait(false);
            viewModel.ProductTurnoverStatistics = await Query<ProductTurnoverStatistic, ProductTurnoverCriteria>(request).ConfigureAwait(false);
            viewModel.SportStatistics = await Query<SportStatistic, SportCriteria>(request).ConfigureAwait(false);
            viewModel.BetTypeStatistics = await Query<BetTypeStatistic, BetTypeCriteria>(request).ConfigureAwait(false);
            viewModel.EventStatistics = await Query<EventStatistic, EventCriteria>(request).ConfigureAwait(false);
            viewModel.SummaryStatistic = QuerySummaryStatistic(viewModel.MonthStatistics);

            return viewModel;
        }

        private SummaryStatistic QuerySummaryStatistic(List<MonthStatistic> monthStatistics)
        {
            return new SummaryStatistic
            {
                BetCount = monthStatistics.Sum(m => m.BetCount),
                Turnover = monthStatistics.Sum(m => m.Turnover),
                WinLoss = monthStatistics.Sum(m => m.WinLoss),
            };
        }

        private async Task<List<TResult>> Query<TResult, TCriteria>(SummaryHttpParameterJson message) where TCriteria : ICriteria
        {
            var criteria = Mapper.Map<TCriteria>(message);
            var entities = await repository.FetchAsync<TResult>(criteria).ConfigureAwait(false);
            return entities.ToList();
        }
    }
}