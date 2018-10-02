using System.Threading.Tasks;
using AutoMapper;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;

namespace UniversalReports.PunterAnalysis.Shared
{
    public class HandlerExcelBase
    {
        private readonly PunterAnalysisService punterAnalysisService;

        private readonly ExcelSettingFactory excelSettingFactory;

        private readonly PunterAnalysisExcelBuilder excelBuilder;

        protected HandlerExcelBase(PunterAnalysisService punterAnalysisService, ExcelSettingFactory excelSettingFactory, PunterAnalysisExcelBuilder excelBuilder)
        {
            this.punterAnalysisService = punterAnalysisService;
            this.excelSettingFactory = excelSettingFactory;
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
            var excelSetting = excelSettingFactory.CreateSetting(excelSettingParams);
            var excelPackage = excelBuilder.CreateExcelPackage(excelViewModel, excelSetting);
            return excelPackage;
        }
    }
}