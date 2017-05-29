using AutoMapper;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Core
{
    public class HandlerExcelBase
    {
        private readonly PunterAnalysisService punterAnalysisService;

        private readonly ExcelSettingFactory setting;

        private readonly PunterAnalysisExcelBuilder excelBuilder;

        protected HandlerExcelBase(PunterAnalysisService punterAnalysisService, ExcelSettingFactory setting, PunterAnalysisExcelBuilder excelBuilder)
        {
            this.punterAnalysisService = punterAnalysisService;
            this.setting = setting;
            this.excelBuilder = excelBuilder;
        }

        protected async Task<ExcelPackage> Handle<TCriteria, TModel, TExcelModel>(IRequest<ExcelPackage> message)
            where TCriteria : ICriteria
            where TModel : class, new()
            where TExcelModel : class, new()
        {
            var criteria = Mapper.Map<TCriteria>(message);
            var model = await punterAnalysisService.Query<TModel>(criteria).ConfigureAwait(false);
            var excelViewModel = Mapper.Map<SummaryEntity<TExcelModel>>(model);
            var excelSettingParams = Mapper.Map<ExcelSettingParams>(message);
            var excelSetting = setting.CreateSetting(excelSettingParams);
            var excelPackage = excelBuilder.CreateExcelPackage(excelViewModel, excelSetting);
            return excelPackage;
        }
    }
}
