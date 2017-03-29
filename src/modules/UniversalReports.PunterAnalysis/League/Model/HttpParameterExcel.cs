using MediatR;
using OfficeOpenXml;

namespace UniversalReports.PunterAnalysis.League.Model
{
    public class HttpParameterExcel : IRequest<ExcelPackage>
    {
    }
}