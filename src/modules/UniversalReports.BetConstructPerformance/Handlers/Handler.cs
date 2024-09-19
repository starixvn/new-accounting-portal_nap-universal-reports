using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.BetConstructPerformance.Criteria;
using UniversalReports.BetConstructPerformance.Models;
using UniversalReports.BetConstructPerformance.Requests;
using UniversalReports.BetConstructPerformance.Services;

namespace UniversalReports.BetConstructPerformance.Handlers
{
    public class Handler : IRequestHandler<SportRequest, SportModel>
    {
        private readonly BetConstructPerformanceService service;

        public Handler(BetConstructPerformanceService service)
        {
            this.service = service;
        }

        public Task<SportModel> Handle(SportRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<SportCriteria>(request);
            return service.GetSports(criteria);
        }
    }
}
