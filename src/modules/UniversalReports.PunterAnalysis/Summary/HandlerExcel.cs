using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.Summary
{
    public class HandlerExcel : IRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private readonly SummaryService summaryService;

        private readonly ExcelSettingFactory excelSettingFactory;

        private readonly PunterAnalysisExcelBuilder excelBuilder;

        public HandlerExcel(SummaryService summaryService, ExcelSettingFactory excelSettingFactory, PunterAnalysisExcelBuilder excelBuilder)
        {
            this.summaryService = summaryService;
            this.excelSettingFactory = excelSettingFactory;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<Criteria>(request);
            var model = await summaryService.GetSummaries(criteria);
            var excelViewModel = Mapper.Map<SummaryEntity<SummaryExcelModel>>(model);
            var excelSettingParams = Mapper.Map<ExcelSettingParams>(request);
            var excelSetting = excelSettingFactory.CreateSetting(excelSettingParams);
            var excelPackage = excelBuilder.CreateExcelPackage(excelViewModel, excelSetting);
            return excelPackage;
        }
    }
}