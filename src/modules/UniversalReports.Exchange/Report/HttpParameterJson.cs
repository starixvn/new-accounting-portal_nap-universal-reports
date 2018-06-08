using System;
using Linq.DynamicSum;
using MediatR;

namespace UniversalReports.Exchange.Report
{
    public class HttpParameterJson : IRequest<SummaryEntity<ExchangeEntity>>
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string LicenseeId { get; set; }

        public string SportType { get; set; }
    }
}