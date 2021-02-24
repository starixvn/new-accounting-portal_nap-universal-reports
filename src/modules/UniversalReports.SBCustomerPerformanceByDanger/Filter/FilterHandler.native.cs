using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalReports.SBCustomerPerformanceByDanger.Filter
{
    public class FilterHandler : RequestHandler<MoveBetDateQueryHttpParameter, DateTime>,
        IRequestHandler<SportQueryHttpParameter, List<SportModel>>,
        IRequestHandler<DivisionQueryHttpParameter, IEnumerable<DivisionModel>>,
        IRequestHandler<LeagueGroupQueryHttpParameter, IEnumerable<LeagueGroupModel>>,
        IRequestHandler<LeagueQueryHttpParameter, IEnumerable<string>>
        
    {
        private readonly FilterService filterService;

        public FilterHandler(FilterService filterService)
        {
            this.filterService = filterService;
        }

        public async Task<IEnumerable<LeagueGroupModel>> Handle(LeagueGroupQueryHttpParameter request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<LeagueGroupQueryCriteria>(request);
            return await filterService.GetLeagueGroup(criteria);
        }

        public async Task<IEnumerable<string>> Handle(LeagueQueryHttpParameter request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<LeagueQueryCriteria>(request);
            return await filterService.GetLeagueSuggestion(criteria);
        }

        public async Task<IEnumerable<DivisionModel>> Handle(DivisionQueryHttpParameter request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<DivisionQueryCriteria>(request);
            return await filterService.GetDivision(criteria);
        }

        public async Task<List<SportModel>> Handle(SportQueryHttpParameter request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<SportQueryCriteria>(request);
            return await filterService.GetSport(criteria);
        }

        protected override DateTime Handle(MoveBetDateQueryHttpParameter request)
        {
            return filterService.GetMoveBetDate();
        } 
    }
}