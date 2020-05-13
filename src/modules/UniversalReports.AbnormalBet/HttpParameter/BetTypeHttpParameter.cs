using MediatR;
using System.Collections.Generic;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.HttpParameter
{
    public class BetTypeHttpParameter : IRequest<IEnumerable<FilterItemModel>>
    {
        public string SportId { get; set; }

    }
}
