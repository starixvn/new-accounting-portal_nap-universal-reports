using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfficeOpenXml;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.PunterAnalysis.SportType.Model;

namespace UniversalReports.PunterAnalysis.SportType
{
    public class HandlerExcel : HandlerExcelBase, IRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        public HandlerExcel(PunterAnalysisService punterAnalysisService, ExcelSettingFactory setting, PunterAnalysisExcelBuilder excelBuilder)
            : base(punterAnalysisService, setting, excelBuilder)
        {
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel request, CancellationToken cancellationToken)
        {
            return await Handle<Criteria, SportTypeModel, SportTypeExcelModel>(request).ConfigureAwait(false);
        }
    }
}