using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalReports.SBCustomerPerformanceByDanger.Report
{
    public class ReportExcelHandler : IRequestHandler<CustomerPerformanceByDangerQueryExcelHttpParameter, ExcelPackage>
    {
        private readonly ReportService service;

        private readonly ReportExcelBuilder builder;

        public ReportExcelHandler(ReportService service, ReportExcelBuilder builder)
        {
            this.service = service;
            this.builder = builder;
        }

        public async Task<ExcelPackage> Handle(
            CustomerPerformanceByDangerQueryExcelHttpParameter request,
            CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<CustomerPerformanceByDangerQueryCriteria>(request);
            var reportData = await service.GetCustomerPerformanceByDanger(criteria);
            var excelModel = Mapper.Map<SummaryEntity<CustomerPerformanceByDangerExcelModel>>(reportData);
            var excelPackage = builder.Build(request.Title, excelModel);
            return excelPackage;
        }
    }
}