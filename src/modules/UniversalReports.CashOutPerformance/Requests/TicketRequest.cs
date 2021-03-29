using Linq.DynamicSum;
using MediatR;
using System;
using UniversalReports.CashOutPerformance.Models;

namespace UniversalReports.CashOutPerformance.Requests
{
    public class TicketRequest : IRequest<SummaryEntity<TicketModel>>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Sports { get; set; }

        public string Sites { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
