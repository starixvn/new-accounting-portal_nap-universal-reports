using System;
using System.Collections.Generic;
using MediatR;

namespace UniversalReports.Exchange.Report
{
    public class HttpParameterJson : IRequest<IEnumerable<ExchangeEntity>>
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string LicenseeId { get; set; }

        public string SportType { get; set; }
    }
}