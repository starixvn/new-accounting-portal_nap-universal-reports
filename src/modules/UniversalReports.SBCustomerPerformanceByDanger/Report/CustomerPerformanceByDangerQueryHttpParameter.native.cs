using Linq.DynamicSum;
using MediatR;
using System;

namespace UniversalReports.SBCustomerPerformanceByDanger.Report
{
    public class CustomerPerformanceByDangerQueryHttpParameter : IRequest<SummaryEntity<CustomerPerformanceByDangerModel>>
    {
        public DateTime WinlostDate { get; set; }

        public string Divisions { get; set; }

        public string DangerLevels { get; set; }

        public string SportBettypes { get; set; }

        public string LeagueName { get; set; }

        public string LeagueGroupIDs { get; set; }

        public string LiveStatus { get; set; }

        public int TopUsers { get; set; }
    }
}