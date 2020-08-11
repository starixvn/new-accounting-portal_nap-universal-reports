using MediatR;
using System.Collections.Generic;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class SiteHttpParameter : IRequest<IEnumerable<Site>>
    {
    }
}