using AutoMapper;
using MediatR;
using OfficeOpenXml;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.BetType
{
    public class HandlerExcel : HandlerExcelBase, IAsyncRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        public HandlerExcel(IMapper mapper, PunterAnalysisService punterAnalysisService, ExcelSettingFactory setting, PunterAnalysisExcelBuilder excelBuilder)
            : base(mapper, punterAnalysisService, setting, excelBuilder)
        {
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel message)
        {
            return await Handle<Criteria, BetTypeModel, BetTypeExcelModel>(message).ConfigureAwait(false);
        }
    }
}
