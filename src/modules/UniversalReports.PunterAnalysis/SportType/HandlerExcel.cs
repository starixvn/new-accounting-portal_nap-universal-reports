using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OfficeOpenXml;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.PunterAnalysis.SportType.Model;

namespace UniversalReports.PunterAnalysis.SportType
{
    public class HandlerExcel : HandlerExcelBase, IAsyncRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        public HandlerExcel(PunterAnalysisService punterAnalysisService, ExcelSettingFactory setting, PunterAnalysisExcelBuilder excelBuilder)
            : base(punterAnalysisService, setting, excelBuilder)
        {
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel message)
        {
            return await Handle<Criteria, SportTypeModel, SportTypeExcelModel>(message).ConfigureAwait(false);
        }
    }
}