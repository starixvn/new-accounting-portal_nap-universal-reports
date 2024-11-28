using MediatR;
using OfficeOpenXml;

namespace UniversalReports.CashOutPerformance.Requests
{
    public class BetTypeDrillDownExcelRequest : IRequest<ExcelPackage>
    {
        public int BetType { get; set; }

        public string OutCome { get; set; }

        public string Title { get; set; }

        public string[] BreadCrumb { get; set; }

        public string Type { get; set; }

        public string Guid { get; set; }
    }
}
