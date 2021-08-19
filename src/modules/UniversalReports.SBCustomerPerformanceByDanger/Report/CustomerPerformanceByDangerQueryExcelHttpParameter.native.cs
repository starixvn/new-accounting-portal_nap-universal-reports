using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;
using System;

namespace UniversalReports.SBCustomerPerformanceByDanger.Report
{
    public class CustomerPerformanceByDangerQueryExcelHttpParameter : IRequest<ExcelPackage>
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Divisions { get; set; }

        public string DangerLevels { get; set; }

        public string SportBettypes { get; set; }

        public string LeagueName { get; set; }

        public string LeagueGroupIDs { get; set; }

        public string LiveStatus { get; set; }

        public int TopUsers { get; set; }

        public string Title { get; set; }
    }
}