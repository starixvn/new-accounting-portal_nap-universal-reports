using System.Collections.Generic;

namespace UniversalReports.VoidingSettledTickets.Models
{
    public class VoidTicketModel
    {
        public List<TicketModel> Tickets { get; set; }

        public TicketModel Total { get; set; }

        public int TotalItems { get; set; }
    }
}