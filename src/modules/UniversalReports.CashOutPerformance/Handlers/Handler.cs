using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.CashOutPerformance.Models;
using UniversalReports.CashOutPerformance.Requests;
using System.Threading;
using UniversalReports.CashOutPerformance.Services;
using UniversalReports.CashOutPerformance.Criteria;
using AutoMapper;
using UniversalReports.CashOutPerformance.ViewModels;

namespace UniversalReports.CashOutPerformance.Handlers
{
    public class Handler : IRequestHandler<SportRequest, IEnumerable<FilterGroupItemModel>>,
        IRequestHandler<LicenseeRequest, IEnumerable<FilterItemModel>>,
        IRequestHandler<TicketRequest, TicketViewModel>,
        IRequestHandler<LeagueRequest, IEnumerable<LeagueModel>>,
        IRequestHandler<LeagueGroupRequest, IEnumerable<FilterItemModel>>
    {
        private readonly CashOutPerformanceService service;

        public Handler(CashOutPerformanceService service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<FilterGroupItemModel>> Handle(SportRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<SportCriteria>(request);
            return await service.GetSportBettypes(criteria);
        }

        public async Task<IEnumerable<FilterItemModel>> Handle(LicenseeRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<LicenseeCriteria>(request);
            return await service.GetLicensees(criteria);
        }

        public async Task<TicketViewModel> Handle(TicketRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<TicketCriteria>(request);
            return await service.GetTickets(criteria);
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
    }
}