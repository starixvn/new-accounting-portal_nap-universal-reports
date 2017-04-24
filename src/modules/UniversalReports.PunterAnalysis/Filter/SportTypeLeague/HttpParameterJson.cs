using MediatR;
using System;
using System.Collections.Generic;

namespace UniversalReports.PunterAnalysis.Filter.SportTypeLeague
{
    public class HttpParameterJson: IRequest<IEnumerable<SportTypeLeagueEntity>>
    {
        public int SportId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
    }
}
