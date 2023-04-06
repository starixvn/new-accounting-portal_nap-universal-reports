using MediatR;
using System.Collections.Generic;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class BetFromHttpParameter : IRequest<IEnumerable<BetFrom>>
    {
    }
}
