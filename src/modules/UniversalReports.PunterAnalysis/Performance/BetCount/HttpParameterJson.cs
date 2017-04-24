using MediatR;
using System.Collections.Generic;

namespace UniversalReports.PunterAnalysis.Performance.BetCount
{
    public class HttpParameterJson : IRequest<IEnumerable<BetCountModel>>
    {
    }
}
