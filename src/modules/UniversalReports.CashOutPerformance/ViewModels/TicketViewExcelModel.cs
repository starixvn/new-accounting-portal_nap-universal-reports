using System.Collections.Generic;
using UniversalReports.CashOutPerformance.Models;

namespace UniversalReports.CashOutPerformance.ViewModels
{
    public class TicketViewExcelModel
    {
        public IEnumerable<TicketExcelModel> TicketList { get; set; }

        public TicketExcelModel TotalTicket { get; set; }

        public int Total { get; set; }
    }
}
