using MediatR;
using System;
using System.Collections.Generic;

namespace UniversalReports.PunterAnalysis.Filter.SportTypeLeague
{
    public class HttpParameterJson : IRequest<IEnumerable<SportTypeLeagueEntity>>
    {
        public int SportId { get; set; }

        public string SearchText { get; set; }

        public bool SearchExactly { get; set; }
    }
}
