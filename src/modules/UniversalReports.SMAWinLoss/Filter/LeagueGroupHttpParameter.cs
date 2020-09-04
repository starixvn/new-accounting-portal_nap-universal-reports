using MediatR;
using System.Collections.Generic;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class LeagueGroupHttpParameter : IRequest<IEnumerable<LeagueGroup>>
    {
    }
}