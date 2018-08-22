using System.Collections.Generic;
using MediatR;

namespace UniversalReports.ActualMemberBet.Filter
{
    public class OddsHttpParameter : IRequest<IEnumerable<Odds>>
    {
    }
}
