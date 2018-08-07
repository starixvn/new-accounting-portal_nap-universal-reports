using System;
using Linq.DynamicSum;
using MediatR;

namespace UniversalReports.ActualMemberBet.Product
{
    public class HttpParameter : IRequest<SummaryEntity<ProductActualMemberBet>>
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int SiteType { get; set; }

        public int CurrencyId { get; set; }

        public int OddsType { get; set; }
    }
}
