using MediatR;
using System.Collections.Generic;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.HttpParameter
{
    public class SiteHttpParameter : IRequest<IEnumerable<FilterItemModel>>
    {
    }
}
