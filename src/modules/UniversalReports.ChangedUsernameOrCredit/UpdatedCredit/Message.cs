using MediatR;
using System.Collections.Generic;
using UniversalReports.UpdatedUsernameAndCredit.Common;

namespace UniversalReports.UpdatedUsernameAndCredit.UpdatedCredit
{
    public class Message : BaseMessage, IRequest<IEnumerable<UpdatedCreditModel>>
    {
    }
}
