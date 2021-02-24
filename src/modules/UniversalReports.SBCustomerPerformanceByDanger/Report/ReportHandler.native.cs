using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalReports.SBCustomerPerformanceByDanger.Report
{
    public class ReportHandler : IRequestHandler<CustomerPerformanceByDangerQueryHttpParameter, SummaryEntity<CustomerPerformanceByDangerModel>>
    {
        private readonly ReportService service;

        public ReportHandler(ReportService service)
        {
            this.service = service;
        }

        public async Task<SummaryEntity<CustomerPerformanceByDangerModel>> Handle(
            CustomerPerformanceByDangerQueryHttpParameter request,
            CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<CustomerPerformanceByDangerQueryCriteria>(request);
            return await service.GetCustomerPerformanceByDanger(criteria);
        }
    }
}