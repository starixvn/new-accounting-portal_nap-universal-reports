using System.Collections.Generic;
using MediatR;
using UniversalReports.UpdatedUsernameCredit.Common;

namespace UniversalReports.UpdatedUsernameCredit.UpdatedUsername
{
    public class Message : BaseMessage, IRequest<IEnumerable<UpdatedUsernameModel>>
    {
    }
}