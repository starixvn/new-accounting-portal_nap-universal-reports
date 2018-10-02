using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.BetCount
{
    public class HandlerExcel : IRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private readonly BetCountService betCountService;

        private readonly ExcelSettingFactory excelSettingFactory;

        private readonly PunterAnalysisExcelBuilder excelBuilder;

        public HandlerExcel(BetCountService betCountService, ExcelSettingFactory excelSettingFactory, PunterAnalysisExcelBuilder excelBuilder)
        {
            this.betCountService = betCountService;
            this.excelSettingFactory = excelSettingFactory;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<Criteria>(request);
            var model = await betCountService.Query(criteria).ConfigureAwait(false);
            var excelViewModel = Mapper.Map<SummaryEntity<BetCountExcelModel>>(model);
            var excelSettingParams = Mapper.Map<ExcelSettingParams>(request);
            var excelSetting = excelSettingFactory.CreateSetting(excelSettingParams);
            var excelPackage = excelBuilder.CreateExcelPackage(excelViewModel, excelSetting);
            return excelPackage;
        }
    }
}