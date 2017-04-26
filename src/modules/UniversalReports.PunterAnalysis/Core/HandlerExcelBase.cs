using AutoMapper;
using Fanex.Data.Repository;
using MediatR;
using OfficeOpenXml;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Core
{
    public abstract class HandlerExcelBase
    {
        private readonly IMapper mapper;

        private readonly PunterAnalysisService punterAnalysisService;

        private readonly ExcelSettingFactory setting;

        private readonly PunterAnalysisExcelBuilder excelBuilder;

        protected HandlerExcelBase(IMapper mapper, PunterAnalysisService punterAnalysisService, ExcelSettingFactory setting, PunterAnalysisExcelBuilder excelBuilder)
        {
            this.mapper = mapper;
            this.punterAnalysisService = punterAnalysisService;
            this.setting = setting;
            this.excelBuilder = excelBuilder;
        }

        protected async Task<ExcelPackage> Handle<TCriteria, TModel, TExcelModel>(IRequest<ExcelPackage> message)
            where TCriteria : ICriteria
            where TModel : class, new()
            where TExcelModel : class, new()
        {
            var criteria = mapper.Map<TCriteria>(message);
            var model = await punterAnalysisService.Query<TModel>(criteria);
            var excelViewModel = mapper.Map<ReportModelBase<TExcelModel>>(model);
            var excelSettingParams = mapper.Map<ExcelSettingParams>(message);
            var excelSetting = setting.CreateSetting(excelSettingParams);
            var excelPackage = excelBuilder.CreateExcelPackage(excelViewModel, excelSetting);
            return excelPackage;
        }
    }
}
