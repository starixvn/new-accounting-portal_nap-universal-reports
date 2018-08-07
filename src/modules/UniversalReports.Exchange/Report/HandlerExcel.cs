using System.Threading.Tasks;
using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;

namespace UniversalReports.Exchange.Report
{
    public class HandlerExcel : IAsyncRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private readonly Service service;

        private readonly ExcelBuilder excelBuilder;

        public HandlerExcel(Service service, ExcelBuilder excelBuilder)
        {
            this.service = service;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel message)
        {
            var jsonMessage = Mapper.Map<HttpParameterJson>(message);
            var exchange = await service.Query(jsonMessage).ConfigureAwait(false);
            var exchangeExcelModel = Mapper.Map<SummaryEntity<ExchangeExcelEntity>>(exchange);
            var excelPackage = excelBuilder.Build(message, exchangeExcelModel);
            return excelPackage;
        }
    }
}
