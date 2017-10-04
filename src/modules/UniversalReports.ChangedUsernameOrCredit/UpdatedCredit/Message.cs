using System.Collections.Generic;
using MediatR;
using UniversalReports.UpdatedUsernameAndCredit.Common;

namespace UniversalReports.UpdatedUsernameAndCredit.UpdatedCredit
{
    public class Message : BaseMessage, IRequest<IEnumerable<UpdatedCreditModel>>
    {
    }
}