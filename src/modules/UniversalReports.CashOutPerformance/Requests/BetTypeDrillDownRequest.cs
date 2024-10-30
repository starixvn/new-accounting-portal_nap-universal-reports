using MediatR;
using UniversalReports.CashOutPerformance.Models;
using UniversalReports.CashOutPerformance.ViewModels;

namespace UniversalReports.CashOutPerformance.Requests
{
    public class BetTypeDrillDownRequest : IRequest<TicketViewModel<BetTypeLevelModel>>
    {
    }
}
