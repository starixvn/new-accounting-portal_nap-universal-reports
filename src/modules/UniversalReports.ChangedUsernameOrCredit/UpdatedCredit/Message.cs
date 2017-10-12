using System.Collections.Generic;
using MediatR;
using UniversalReports.UpdatedUsernameCredit.Common;

namespace UniversalReports.UpdatedUsernameCredit.UpdatedCredit
{
    public class Message : BaseMessage, IRequest<IEnumerable<UpdatedCreditModel>>
    {
    }
}