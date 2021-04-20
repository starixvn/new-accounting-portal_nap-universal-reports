using MediatR;
using System.Collections.Generic;
using UniversalReports.CashOutPerformance.Models;

namespace UniversalReports.CashOutPerformance.Requests
{
    public class SportRequest : IRequest<IEnumerable<FilterItemModel>>
    {
    }
}
