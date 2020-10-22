using MediatR;
using OfficeOpenXml;
using System;

namespace UniversalReports.VoidingSettledTickets.Requests
{
    public class ProductExcelRequest : IRequest<ExcelPackage>
    {
        public DateTime WinlostDate { get; set; }

        public int? MatchId { get; set; }

        public DateTime? VoidTime { get; set; }
    }
}