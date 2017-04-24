using MediatR;
using System.Collections.Generic;

namespace UniversalReports.PunterAnalysis.Filter.SportTypeLeague
{
    public class HttpParameterJson: IRequest<IEnumerable<SportTypeLeagueEntity>>
    {
        public int SportId { get; set; }
    }
}
