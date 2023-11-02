using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalReports.Exchange.Report
{
    public class LicenseeHandlerExcel : IRequestHandler<LicenseeHttpParameterExcel, ExcelPackage>
    {
        private readonly Service service;

        private readonly LicenseeExcelBuilder excelBuilder;

        public LicenseeHandlerExcel(Service service, LicenseeExcelBuilder excelBuilder)
        {
            this.service = service;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(LicenseeHttpParameterExcel request, CancellationToken cancellationToken)
        {
            var jsonMessage = Mapper.Map<LicenseeHttpParameterJson>(request);
            var exchange = await service.QueryLicensee(jsonMessage);
            var exchangeExcelModel = Mapper.Map<ExchangeExcelModel>(exchange);
            var excelPackage = excelBuilder.Build(request, exchangeExcelModel);
            return excelPackage;
        }
    }
}