using MediatR;
using System.Collections.Generic;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.HttpParameter
{
    public class LeagueHttpParameter : IRequest<IEnumerable<FilterItemModel>>
    {
        public string SportId { get; set; }

        public string SearchText { get; set; }

        public bool SearchExactly { get; set; }
    }
}