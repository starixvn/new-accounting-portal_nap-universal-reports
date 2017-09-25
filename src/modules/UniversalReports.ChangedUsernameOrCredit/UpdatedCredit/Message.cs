using MediatR;
using System;
using System.Collections.Generic;

namespace UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedCredit
{
    public class Message : IRequest<IEnumerable<UpdatedCreditModel>>
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Username { get; set; }
    }
}
