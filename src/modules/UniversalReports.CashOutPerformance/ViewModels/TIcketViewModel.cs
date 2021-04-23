using System.Collections.Generic;
using UniversalReports.CashOutPerformance.Models;

namespace UniversalReports.CashOutPerformance.ViewModels
{
    public class TicketViewModel
    {
        public IEnumerable<TicketModel> TicketList { get; set; }

        public TicketModel TotalTicket { get; set; }

        public int Total { get; set; }
    }
}
