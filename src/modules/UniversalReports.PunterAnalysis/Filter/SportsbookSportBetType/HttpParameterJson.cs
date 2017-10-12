using System.Collections.Generic;
using MediatR;

namespace UniversalReports.PunterAnalysis.Filter.SportsbookSportBetType
{
    public class HttpParameterJson : IRequest<IEnumerable<SportsbookSportBetTypeEntity>>
    {
    }
}