using MediatR;
using System;
using UniversalReports.CashOutPerformance.ViewModels;

namespace UniversalReports.CashOutPerformance.Requests
{
    public class TicketRequest : IRequest<TicketViewModel>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Sports { get; set; }

        public string Sites { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
