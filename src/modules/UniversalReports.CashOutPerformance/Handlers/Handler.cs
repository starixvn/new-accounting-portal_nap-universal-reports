using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.CashOutPerformance.Models;
using UniversalReports.CashOutPerformance.Requests;
using System.Threading;
using UniversalReports.CashOutPerformance.Services;
using UniversalReports.CashOutPerformance.Criteria;
using AutoMapper;
using Linq.DynamicSum;

namespace UniversalReports.CashOutPerformance.Handlers
{
    public class Handler : IRequestHandler<SportRequest, IEnumerable<SportModel>>,
        IRequestHandler<LicenseeRequest, IEnumerable<LicenseeModel>>,
        IRequestHandler<TicketRequest, SummaryEntity<TicketModel>>
    {
        private readonly CashOutPerformanceService service;

        public Handler(CashOutPerformanceService service)
        {
            this.service = service;
        }
        public async Task<IEnumerable<SportModel>> Handle(SportRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<SportCriteria>(request);
            return await service.GetSports(criteria);
        }

        public async Task<IEnumerable<LicenseeModel>> Handle(LicenseeRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<LicenseeCriteria>(request);
            return await service.GetLicensees(criteria);
        }

        public async Task<SummaryEntity<TicketModel>> Handle(TicketRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<TicketCriteria>(request);
            return await service.GetTickets(criteria);
        }
    }
}
