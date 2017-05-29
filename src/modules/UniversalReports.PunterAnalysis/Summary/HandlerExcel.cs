using AutoMapper;
using MediatR;
using OfficeOpenXml;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.Summary
{
    public class HandlerExcel : HandlerExcelBase, IAsyncRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        public HandlerExcel(PunterAnalysisService punterAnalysisService, ExcelSettingFactory setting, PunterAnalysisExcelBuilder excelBuilder)
            : base(punterAnalysisService, setting, excelBuilder)
        {
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel message)
        {
            return await Handle<Criteria, SummaryModel, SummaryExcelModel>(message).ConfigureAwait(false);
        }
    }
}
