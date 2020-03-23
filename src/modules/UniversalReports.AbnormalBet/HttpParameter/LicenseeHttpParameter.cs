using MediatR;
using System;
using System.Collections.Generic;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.HttpParameter
{
    public class LicenseeHttpParameter : IRequest<IEnumerable<LicenseeModel>>
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int Reason { get; set; }

        public int Sport { get; set; }

        public int BetType { get; set; }

        public int Licensee { get; set; }

        public bool IsTest { get; set; }
    }
}
