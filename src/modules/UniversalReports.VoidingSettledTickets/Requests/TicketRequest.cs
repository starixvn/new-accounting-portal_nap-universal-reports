using MediatR;
using System;
using UniversalReports.VoidingSettledTickets.Models;

namespace UniversalReports.VoidingSettledTickets.Requests
{
    public class TicketRequest : IRequest<VoidTicketModel>
    {
        public DateTime WinlostDate { get; set; }

        public int? MatchId { get; set; }

        public DateTime? VoidTime { get; set; }

        public int ProductGroupId { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}