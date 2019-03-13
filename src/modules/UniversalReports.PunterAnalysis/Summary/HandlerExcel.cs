using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfficeOpenXml;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.Summary
{
    public class HandlerExcel : HandlerExcelBase, IRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        public HandlerExcel(PunterAnalysisService punterAnalysisService, ExcelSettingFactory excelSettingFactory, PunterAnalysisExcelBuilder excelBuilder)
            : base(punterAnalysisService, excelSettingFactory, excelBuilder)
        {
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel request, CancellationToken cancellationToken)
        {
            return await Handle<Criteria, SummaryModel, SummaryExcelModel>(request);
        }
    }
}