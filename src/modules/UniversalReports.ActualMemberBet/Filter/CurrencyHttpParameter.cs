using System.Collections.Generic;
using MediatR;

namespace UniversalReports.ActualMemberBet.Filter
{
    public class CurrencyHttpParameter : IRequest<IEnumerable<Currency>>
    {
    }
}
