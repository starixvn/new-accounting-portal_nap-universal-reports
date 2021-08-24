using MediatR;
using System.Collections.Generic;
using UniversalReports.CashOutPerformance.Models;

namespace UniversalReports.CashOutPerformance.Requests
{
    public class BetTypeRequest : IRequest<IEnumerable<FilterItemModel>>
    {
    }
}