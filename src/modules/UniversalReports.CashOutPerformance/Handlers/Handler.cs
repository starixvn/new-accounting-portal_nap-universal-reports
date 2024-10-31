using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Fanex.Caching;
using Linq.DynamicSum;
using UniversalReports.CashOutPerformance.Criteria;
using UniversalReports.CashOutPerformance.Models;
using UniversalReports.CashOutPerformance.Requests;
using UniversalReports.CashOutPerformance.Services;
using UniversalReports.CashOutPerformance.ViewModels;

namespace UniversalReports.CashOutPerformance.Handlers
{
    public class Handler : IRequestHandler<SportRequest, IEnumerable<FilterGroupItemModel>>,
        IRequestHandler<LicenseeRequest, IEnumerable<SiteModel>>,
        IRequestHandler<SportLevelRequest, SportLevelModel>,
        IRequestHandler<TicketRequest<EventStatusLevelModel>, TicketViewModel<EventStatusLevelModel>>,
        IRequestHandler<TicketRequest<BetTypeLevelModel>, TicketViewModel<BetTypeLevelModel>>,
        IRequestHandler<TicketRequest<MatchDetailLevelModel>, TicketViewModel<MatchDetailLevelModel>>,
        IRequestHandler<LeagueRequest, IEnumerable<LeagueModel>>,
        IRequestHandler<LeagueGroupRequest, IEnumerable<FilterItemModel>>,
        IRequestHandler<BetTypeDrillDownRequest, TicketViewModel<BetTypeLevelModel>>
    {
        private const string BetTypeDataCacheKey = "BetTypeDataCacheKey";

        private readonly CashOutPerformanceService service;

        private readonly ICacheService cacheService;

        public Handler(CashOutPerformanceService service, ICacheService cacheService)
        {
            this.service = service;
            this.cacheService = cacheService;
        }

        public async Task<IEnumerable<FilterGroupItemModel>> Handle(SportRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<SportCriteria>(request);
            return await service.GetSportBettypes(criteria);
        }

        public async Task<IEnumerable<SiteModel>> Handle(LicenseeRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<LicenseeCriteria>(request);
            return await service.GetLicensees(criteria);
        }

        public async Task<SportLevelModel> Handle(SportLevelRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<SportLevelCriteria>(request);
            return await service.GetSportLevel(criteria);
        }

        public async Task<TicketViewModel<EventStatusLevelModel>> Handle(TicketRequest<EventStatusLevelModel> request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<EventStatusLevelCriteria>(request);
            return await service.GetTickets<EventStatusLevelModel, EventStatusLevelCriteria>(criteria);
        }

        public async Task<TicketViewModel<BetTypeLevelModel>> Handle(TicketRequest<BetTypeLevelModel> request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<BetTypeLevelCriteria>(request);
            var data = await service.GetTickets<BetTypeLevelModel, BetTypeLevelCriteria>(criteria);
            await cacheService.SetAsync(BetTypeDataCacheKey, data);
            var result = UpdateBetTypeViewModel(data);
            return result;
        }

        public async Task<TicketViewModel<MatchDetailLevelModel>> Handle(TicketRequest<MatchDetailLevelModel> request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<MatchDetailLevelCriteria>(request);
            return await service.GetTickets<MatchDetailLevelModel, MatchDetailLevelCriteria>(criteria);
        }

        public async Task<IEnumerable<LeagueModel>> Handle(LeagueRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<LeagueCriteria>(request);
            return await service.GetLeagues(criteria);
        }

        public async Task<IEnumerable<FilterItemModel>> Handle(LeagueGroupRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<LeagueGroupCriteria>(request);
            return await service.GetLeagueGroups(criteria);
        }

        private static TicketViewModel<BetTypeLevelModel> UpdateBetTypeViewModel(TicketViewModel<BetTypeLevelModel> data)
        {
            var result = new TicketViewModel<BetTypeLevelModel>();
            var ticketList = new List<BetTypeLevelModel>();
            var groups = data.TicketList.GroupBy(x => x.BetType);
            foreach (var group in groups)
            {
                var betType = group.DynamicSum();
                var groupedOutComes = group.GroupBy(item => item.OutCome);
                foreach (var outCome in groupedOutComes)
                {
                    var item = outCome.DynamicSum();
                    betType.ChildItems.Add(item);
                }
                ticketList.Add(betType);
            }

            result.TicketList = ticketList;
            result.Total = data.Total;
            result.TotalTicket = data.TotalTicket;
            return result;
        }

        public async Task<TicketViewModel<BetTypeLevelModel>> Handle(BetTypeDrillDownRequest request, CancellationToken cancellationToken)
        {
            return await cacheService.GetAsync<TicketViewModel<BetTypeLevelModel>>(BetTypeDataCacheKey);
        }
    }
}