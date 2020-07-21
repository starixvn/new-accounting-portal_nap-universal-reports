using MediatR;
using System.Collections.Generic;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class SportHttpParameter : IRequest<IEnumerable<Sport>>
    {
    }
}