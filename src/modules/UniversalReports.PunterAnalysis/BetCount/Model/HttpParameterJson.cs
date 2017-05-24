using Linq.DynamicSum;
using MediatR;
using System;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.BetCount.Model
{
    public class HttpParameterJson : IRequest<SummaryEntity<BetCountModel>>
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
    }
}