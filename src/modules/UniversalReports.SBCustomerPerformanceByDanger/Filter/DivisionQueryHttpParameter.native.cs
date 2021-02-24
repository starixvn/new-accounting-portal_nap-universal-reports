using MediatR;
using System.Collections.Generic;

namespace UniversalReports.SBCustomerPerformanceByDanger.Filter
{
    public class DivisionQueryHttpParameter : IRequest<IEnumerable<DivisionModel>>
    {
    }
}