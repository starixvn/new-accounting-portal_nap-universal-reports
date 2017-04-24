using MediatR;
using System.Collections.Generic;

namespace UniversalReports.PunterAnalysis.Filter.SportsbookSportBetType
{
    public class HttpParameterJson: IRequest<IEnumerable<SportsbookSportBetTypeEntity>>
    {
    }
}
