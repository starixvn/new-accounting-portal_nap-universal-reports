using MediatR;
using OfficeOpenXml;
using System;

namespace UniversalReports.VoidingSettledTickets.Requests
{
    public class TicketExcelRequest : IRequest<ExcelPackage>
    {
        public DateTime WinlostDate { get; set; }

        public int? MatchId { get; set; }

        public DateTime? VoidTime { get; set; }

        public int ProductGroupId { get; set; }

        public string productName { get; set; }

        public int PageIndex { get; } = 0;

        public int PageSize { get; } = 0;
    }
}