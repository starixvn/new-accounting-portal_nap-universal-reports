using MediatR;
using OfficeOpenXml;

namespace UniversalReports.PunterAnalysis.Summary.Model
{
    public class HttpParameterExcel : IRequest<ExcelPackage>
    {
    }
}