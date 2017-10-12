using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OfficeOpenXml;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.BetType
{
    public class HandlerExcel : HandlerExcelBase, IAsyncRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        public HandlerExcel(PunterAnalysisService punterAnalysisService, ExcelSettingFactory setting, PunterAnalysisExcelBuilder excelBuilder)
            : base(punterAnalysisService, setting, excelBuilder)
        {
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel message)
        {
            return await Handle<Criteria, BetTypeModel, BetTypeExcelModel>(message).ConfigureAwait(false);
        }
    }
}