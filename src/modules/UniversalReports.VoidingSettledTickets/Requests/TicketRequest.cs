using MediatR;
using System;
using System.Collections.Generic;
using UniversalReports.VoidingSettledTickets.Models;

namespace UniversalReports.VoidingSettledTickets.Requests
{
    public class TicketRequest : IRequest<List<TicketModel>>
    {
        public DateTime WinlostDate { get; set; }

        public int MatchId { get; set; }

        public DateTime VoidedDate { get; set; }

        public string VoidedTime { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}