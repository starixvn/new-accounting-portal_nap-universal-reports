using AutoMapper;
using MediatR;
using OfficeOpenXml;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.BetType
{
    public class HandlerExcel : IAsyncRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private readonly IMapper mapper;

        private readonly PunterAnalysisService punterAnalysisService;

        private readonly BetTypeExcelSettings settings;

        private readonly PunterAnalysisExcelBuilder excelBuilder;

        public HandlerExcel(IMapper mapper, PunterAnalysisService punterAnalysisService, BetTypeExcelSettings settings, PunterAnalysisExcelBuilder excelBuilder)
        {
            this.mapper = mapper;
            this.punterAnalysisService = punterAnalysisService;
            this.settings = settings;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel message)
        {
            var criteria = mapper.Map<Criteria>(message);
            var model = await punterAnalysisService.Query<BetTypeModel>(criteria);
            var excelViewModel = mapper.Map<ExcelViewModel>(model);
            var excelSettings = await settings.CreateSettings();
            return await excelBuilder.CreateExcelPackage(excelViewModel, excelSettings);
        }
    }
}
