using MediatR;
using OfficeOpenXml;

namespace UniversalReports.PlayForFun.Summary.Model
{
    public class HttpParameterExcel : IRequest<ExcelPackage>
    {
    }
}