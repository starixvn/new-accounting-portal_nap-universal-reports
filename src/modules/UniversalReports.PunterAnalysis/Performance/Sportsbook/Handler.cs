using AutoMapper;
using Fanex.Data.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Performance.Sportsbook.Criteria;
using UniversalReports.PunterAnalysis.Performance.Sportsbook.Model;

namespace UniversalReports.PunterAnalysis.Performance.Sportsbook
{
    public class Handler : IAsyncRequestHandler<SportsbookHttpParameterJson, ViewModelJson>
    {
        private readonly IDynamicRepository repository;

        private readonly IMapper mapper;

        public Handler(IMapper mapper, IDynamicRepository repository)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ViewModelJson> Handle(SportsbookHttpParameterJson message)
        {
            var viewModel = new ViewModelJson
            {
                SportStatistics = await Query<SportStatistic>(message, typeof(SportCriteria)),
                BetCountStatistics = await Query<BetCountStatistic>(message, typeof(BetCountCriteria)),
            };

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

        private async Task<List<TResult>> Query<TResult>(SportsbookHttpParameterJson message, Type criteriaType)
        {
            var criteria = mapper.Map(message, typeof(SportsbookHttpParameterJson), criteriaType);
            var entities = await repository.FetchAsync<TResult>(criteria);
            return entities.ToList();
        }
    }
}