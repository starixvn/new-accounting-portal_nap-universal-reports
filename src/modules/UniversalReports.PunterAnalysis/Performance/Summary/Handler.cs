using AutoMapper;
using Fanex.Data.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Performance.Summary.Criteria;
using UniversalReports.PunterAnalysis.Performance.Summary.Model;

namespace UniversalReports.PunterAnalysis.Performance.Summary
{
    public class Handler : IAsyncRequestHandler<SummaryHttpParameterJson, ViewModelJson>
    {
        private readonly IDynamicRepository repository;

        private readonly IMapper mapper;

        public Handler(IMapper mapper, IDynamicRepository repository)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ViewModelJson> Handle(SummaryHttpParameterJson message)
        {
            var viewModel = new ViewModelJson
            {
                MonthStatistics = await Query<MonthStatistic>(message, typeof(MonthCriteria)),
                ProductTurnoverStatistics = await Query<ProductTurnoverStatistic>(message, typeof(ProductTurnoverCriteria)),
                SportStatistics = await Query<SportStatistic>(message, typeof(SportCriteria)),
                BetTypeStatistics = await Query<BetTypeStatistic>(message, typeof(BetTypeCriteria)),
                EventStatistics = await Query<EventStatistic>(message, typeof(EventCriteria)),
            };

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

        private async Task<List<TResult>> Query<TResult>(SummaryHttpParameterJson message, Type criteriaType)
        {
            var criteria = mapper.Map(message, typeof(SummaryHttpParameterJson), criteriaType);
            var entities = await repository.FetchAsync<TResult>(criteria);
            return entities.ToList();
        }
    }
}