using MediatR;
using OfficeOpenXml;

namespace UniversalReports.PunterAnalysis.BetCount.Model
{
    public class HttpParameterExcel : IRequest<ExcelPackage>
    {
    }
}