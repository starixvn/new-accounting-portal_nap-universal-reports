using MediatR;
using OfficeOpenXml;

namespace UniversalReports.PunterAnalysis.BetType.Model
{
    public class HttpParameterExcel : IRequest<ExcelPackage>
    {
    }
}