using MediatR;
using System.Collections.Generic;

namespace UniversalReports.PunterAnalysis.Performance.EventChoice
{
    public class HttpParameterJson : IRequest<IEnumerable<EventChoiceModel>>
    {
    }
}
