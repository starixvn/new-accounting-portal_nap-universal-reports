using MediatR;
using System;
using System.Collections.Generic;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.HttpParameter
{
    public class MemberHttpParameter : IRequest<IEnumerable<MemberModel>>
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Reason { get; set; }

        public string Sport { get; set; }

        public string BetType { get; set; }

        public string Licensee { get; set; }

        public string Member { get; set; }

        public bool IsTest { get; set; }
    }
}
