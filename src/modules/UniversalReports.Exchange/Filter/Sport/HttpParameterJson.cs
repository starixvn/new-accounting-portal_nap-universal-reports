using System.Collections.Generic;
using MediatR;

namespace UniversalReports.Exchange.Filter.Sport
{
    public class HttpParameterJson : IRequest<IEnumerable<SportEntity>>
    {
    }
}