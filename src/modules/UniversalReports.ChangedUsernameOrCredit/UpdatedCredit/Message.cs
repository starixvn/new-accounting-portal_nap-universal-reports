using MediatR;
using System.Collections.Generic;
using UniversalReports.UpdatedUsernameAndGivenCredit.Common;

namespace UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedCredit
{
    public class Message : BaseMessage, IRequest<IEnumerable<UpdatedCreditModel>>
    {
    }
}
