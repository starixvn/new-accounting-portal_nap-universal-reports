using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;

namespace UniversalReports.Exchange.Report
{
    public class HandlerExcel : IRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private readonly Service service;

        private readonly ExcelBuilder excelBuilder;

        public HandlerExcel(Service service, ExcelBuilder excelBuilder)
        {
            this.service = service;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel request, CancellationToken cancellationToken)
        {
            var jsonMessage = Mapper.Map<HttpParameterJson>(request);
            var exchange = await service.Query(jsonMessage);
            var exchangeExcelModel = Mapper.Map<SummaryEntity<ExchangeExcelEntity>>(exchange);
            var excelPackage = excelBuilder.Build(request, exchangeExcelModel);
            return excelPackage;
        }
    }
}