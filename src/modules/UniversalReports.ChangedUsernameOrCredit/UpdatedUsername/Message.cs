using MediatR;
using System.Collections.Generic;
using UniversalReports.UpdatedUsernameAndGivenCredit.Common;

namespace UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedUsername
{
    public class Message : BaseMessage, IRequest<IEnumerable<UpdatedUsernameModel>>
    {
    }
}
