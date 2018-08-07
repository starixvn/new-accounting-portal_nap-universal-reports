using System;
using Linq.DynamicSum;
using MediatR;

namespace UniversalReports.ActualMemberBet.Bettype
{
    public class HttpParameter : IRequest<SummaryEntity<BetTypeActualMemberBet>>
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int SiteType { get; set; }

        public int CurrencyId { get; set; }

        public int OddsType { get; set; }

        public string KeyId { get; set; }
    }
}
