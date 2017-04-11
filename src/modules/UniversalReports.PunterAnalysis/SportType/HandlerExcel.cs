using AutoMapper;
using MediatR;
using OfficeOpenXml;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.SportType.Model;

namespace UniversalReports.PunterAnalysis.SportType
{
    public class HandlerExcel : IAsyncRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private readonly IMapper mapper;

        private readonly PunterAnalysisService punterAnalysisService;

        private readonly IExcelSetting setting;

        private readonly PunterAnalysisExcelBuilder excelBuilder;

        public HandlerExcel(IMapper mapper, PunterAnalysisService punterAnalysisService, IExcelSetting setting, PunterAnalysisExcelBuilder excelBuilder)
        {
            this.mapper = mapper;
            this.punterAnalysisService = punterAnalysisService;
            this.setting = setting;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel message)
        {
            var criteria = mapper.Map<Criteria>(message);
            var model = await punterAnalysisService.Query<SportTypeModel>(criteria);
            var excelViewModel = mapper.Map<ExcelViewModel>(model);
            var excelSettingParams = mapper.Map<ExcelSettingParams>(message);
            var excelSetting = setting.CreateSetting(excelSettingParams);
            var excelPackage = excelBuilder.CreateExcelPackage(excelViewModel, excelSetting);
            return await Task.FromResult(excelPackage);
        }
    }
}
