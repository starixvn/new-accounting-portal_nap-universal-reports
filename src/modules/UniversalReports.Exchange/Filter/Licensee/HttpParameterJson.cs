using System.Collections.Generic;
using MediatR;

namespace UniversalReports.Exchange.Filter.Licensee
{
    public class HttpParameterJson : IRequest<IEnumerable<LicenseeModel>>
    {
    }
}