using MediatR;
using OfficeOpenXml;
using System;

namespace UniversalReports.PunterAnalysis.BetCount.Model
{
    public class HttpParameterExcel : IRequest<ExcelPackage>
    {
        public int PeriodType { get; set; } = 1;

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int CustId { get; set; }

        public string ListCombinationId { get; set; }

        public int LeagueId { get; set; }

        public int SportId { get; set; }

        public int BetTypeId { get; set; }

        public int LiveStatusId { get; set; }

        public string Title { get; set; }

        public string Filter { get; set; }
    }
}