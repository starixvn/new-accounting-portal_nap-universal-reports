using System.Collections.Generic;
using MediatR;
using UniversalReports.UpdatedUsernameAndCredit.Common;

namespace UniversalReports.UpdatedUsernameAndCredit.UpdatedUsername
{
    public class Message : BaseMessage, IRequest<IEnumerable<UpdatedUsernameModel>>
    {
    }
}