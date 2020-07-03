using Linq.DynamicSum;
using MediatR;
using System;

namespace UniversalReports.SBPerformance.Main
{
    public class HttpParameter : IRequest<SummaryEntity<ItemModel>>
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int TimeRange { get; set; }

        public bool IsShowSite { get; set; }

        public bool IsShowSport { get; set; }

        public bool IsShowLeague { get; set; }

        public bool IsShowCust { get; set; }

        public decimal Margin { get; set; }

        public int Top { get; set; }

        public bool IsShowFullColumn { get; set; }
    }
}