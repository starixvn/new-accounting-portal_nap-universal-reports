using Linq.DynamicSum;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CashOutPerformance.Criteria;
using UniversalReports.CashOutPerformance.Models;
using UniversalReports.CashOutPerformance.ViewModels;

namespace UniversalReports.CashOutPerformance.Utility
{
    public static class ModelsHelper
    {
        public static TicketViewModel<BetTypeLevelModel> UpdateGameTimeLevelModel(List<BetTypeLevelModel> data, GameTimeCriteria criteria)
        {
            var result = new TicketViewModel<BetTypeLevelModel>();
            var ticketList = data.Where(item => item.BetType == criteria.BetType && item.OutCome == criteria.OutCome);
            result.TicketList = ticketList.OrderBy(t => t.GameTime);
            result.TotalTicket = ticketList.DynamicSum();
            return result;
        }
    }
}
