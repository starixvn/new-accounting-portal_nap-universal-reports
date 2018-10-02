using MediatR;
using OfficeOpenXml;

namespace UniversalReports.PunterAnalysis.AssociatedAccount.Model
{
    public class HttpParameterExcel : HttpParameterJson, IRequest<ExcelPackage>
    {
        public string Title { get; set; }

        public string Filter { get; set; }
    }
}