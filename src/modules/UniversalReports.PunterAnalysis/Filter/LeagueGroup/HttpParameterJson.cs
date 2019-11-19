using System.Collections.Generic;
using MediatR;

namespace UniversalReports.PunterAnalysis.Filter.LeagueGroup
{
    public class HttpParameterJson : IRequest<IEnumerable<LeagueGroupEntity>>
    {
    }
}