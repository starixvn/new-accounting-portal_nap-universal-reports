using MediatR;
using System.Collections.Generic;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class LeagueGroupHttpParameter : IRequest<IEnumerable<string>>
    {
        public string Sports { get; set; }

        public string SearchText { get; set; }

        public bool SearchExactly { get; set; }
    }
}