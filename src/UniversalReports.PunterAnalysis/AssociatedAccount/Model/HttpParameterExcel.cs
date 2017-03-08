using MediatR;
using OfficeOpenXml;

namespace UniversalReports.PunterAnalysis.AssociatedAccount.Model
{
    public class HttpParameterExcel : IRequest<ExcelPackage>
    {
    }
}