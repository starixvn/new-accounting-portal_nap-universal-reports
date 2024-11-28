using MediatR;
using UniversalReports.CashOutPerformance.Models;
using UniversalReports.CashOutPerformance.ViewModels;

namespace UniversalReports.CashOutPerformance.Requests
{
    public class BetTypeDrillDownRequest : IRequest<TicketViewModel<BetTypeLevelModel>>
    {
        public int BetType { get; set; }

        public string OutCome { get; set; }

        public string Type { get; set; }

        public string Guid { get; set; }
    }
}
