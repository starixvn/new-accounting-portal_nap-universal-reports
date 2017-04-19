using AutoMapper;
using MediatR;
using OfficeOpenXml;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.BetCount
{
    public class HandlerExcel : IAsyncRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private readonly IMapper mapper;

        private readonly BetCountService betCountService;

        private readonly ExcelSettingFactory setting;

        private readonly PunterAnalysisExcelBuilder excelBuilder;

        public HandlerExcel(IMapper mapper, BetCountService betCountService, ExcelSettingFactory setting, PunterAnalysisExcelBuilder excelBuilder)
        {
            this.mapper = mapper;
            this.betCountService = betCountService;
            this.setting = setting;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel message)
        {
            var criteria = mapper.Map<Criteria>(message);
            var model = await betCountService.Query(criteria);
            var excelViewModel = mapper.Map<ExcelViewModel>(model);
            var excelSettingParams = mapper.Map<ExcelSettingParams>(message);
            var excelSetting = setting.CreateSetting(excelSettingParams);
            var excelPackage = excelBuilder.CreateExcelPackage(excelViewModel, excelSetting);
            return excelPackage;
        }
    }
}
