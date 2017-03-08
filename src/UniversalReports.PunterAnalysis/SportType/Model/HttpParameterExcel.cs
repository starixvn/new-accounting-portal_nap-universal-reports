using MediatR;
using OfficeOpenXml;

namespace UniversalReports.PunterAnalysis.SportType.Model
{
    public class HttpParameterExcel : IRequest<ExcelPackage>
    {
    }
}