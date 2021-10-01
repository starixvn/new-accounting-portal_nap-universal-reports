using MediatR;
using OfficeOpenXml;
using System;

namespace UniversalReports.CashOutPerformance.Requests
{
    public class TicketExcelRequest<T> : IRequest<ExcelPackage>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string SportBettype { get; set; }

        public string Sites { get; set; }

        public string Leagues { get; set; }

        public string LeagueGroupIDs { get; set; }

        public string GlobalShowTime { get; set; }

        public byte LiveIndicator { get; set; }

        public string Title { get; set; }

        public string[] BreadCrumb { get; set; }

        public int PageIndex { get; } = 0;

        public int PageSize { get; } = 0;

        public string Server { get; set; }

        public T ExcelViewModel { get; set; }
    }
}