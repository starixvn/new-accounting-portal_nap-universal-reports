using MediatR;
using System.Collections.Generic;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class CurrencyHttpParameter : IRequest<IEnumerable<Currency>>
    {
    }
}