using System;
using System.Collections.Generic;
using MediatR;

namespace UniversalReports.PunterAnalysis.Filter.League
{
    public class HttpParameterJson : IRequest<IEnumerable<LeagueEntity>>
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int SportId { get; set; }
    }
}