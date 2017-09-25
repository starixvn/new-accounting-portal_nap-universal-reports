using MediatR;
using System;
using System.Collections.Generic;

namespace UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedUsername
{
    public class Message : IRequest<IEnumerable<UpdatedUsernameModel>>
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Username { get; set; }
    }
}
