using MediatR;
using OfficeOpenXml;

namespace UniversalReports.PunterAnalysis.League.Model
{
    public class HttpParameterExcel : IRequest<ExcelPackage>
    {
        public int PeriodType { get; set; }

        public string Title { get; set; }

        public string Filter { get; set; }
    }
}