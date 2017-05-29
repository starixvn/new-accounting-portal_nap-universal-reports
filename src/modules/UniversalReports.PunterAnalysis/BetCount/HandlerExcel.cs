using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.BetCount
{
    public class HandlerExcel : IAsyncRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private readonly BetCountService betCountService;

        private readonly ExcelSettingFactory setting;

        private readonly PunterAnalysisExcelBuilder excelBuilder;

        public HandlerExcel(BetCountService betCountService, ExcelSettingFactory setting, PunterAnalysisExcelBuilder excelBuilder)
        {
            this.betCountService = betCountService;
            this.setting = setting;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel message)
        {
            var criteria = Mapper.Map<Criteria>(message);
            var model = await betCountService.Query(criteria).ConfigureAwait(false);
            var excelViewModel = Mapper.Map<SummaryEntity<BetCountExcelModel>>(model);
            var excelSettingParams = Mapper.Map<ExcelSettingParams>(message);
            var excelSetting = setting.CreateSetting(excelSettingParams);
            var excelPackage = excelBuilder.CreateExcelPackage(excelViewModel, excelSetting);
            return excelPackage;
        }
    }
}
