using MediatR;
using System.Collections.Generic;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.HttpParameter
{
    public class ReasonHttpParameter : IRequest<IEnumerable<ReasonModel>>
    {
    }
}
