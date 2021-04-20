using MediatR;
using OfficeOpenXml;
using System;

namespace UniversalReports.CashOutPerformance.Requests
{
    public class TicketExcelRequest : IRequest<ExcelPackage>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Sports { get; set; }

        public string Sites { get; set; }

        public string Title { get; set; }

        public int PageIndex { get; } = 0;

        public int PageSize { get; } = 0;
    }
}
