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
            var rawData = data.Where(item => item.BetType == criteria.BetType && item.OutCome == criteria.OutCome);
            var ticketList = rawData.GroupBy(x => x.GameTime).Select(ticket => ticket.DynamicSum());
            result.TicketList = ticketList.OrderBy(x => x.GameTime);
            result.TotalTicket = rawData.DynamicSum();
            result.Total = ticketList.Count();
            return result;
        }

        public static TicketViewModel<BetTypeLevelModel> UpdateWinningProbabilityLevelModel(List<BetTypeLevelModel> data, GameTimeCriteria criteria)
        {
            var result = new TicketViewModel<BetTypeLevelModel>();
            var rawData = data.Where(item => item.BetType == criteria.BetType);
            var ticketList = rawData.GroupBy(x => x.WinningProbabilityQuantile).Select(ticket => ticket.DynamicSum());
            result.TicketList = ticketList.OrderBy(x => x.WinningProbabilityQuantile);
            result.TotalTicket = rawData.DynamicSum();
            result.Total = ticketList.Count();
            return result;
        }

        public static TicketViewModel<BetTypeLevelModel> UpdateDetailGameTimeLevelModel(List<BetTypeLevelModel> data, GameTimeCriteria criteria)
        {
            var result = new TicketViewModel<BetTypeLevelModel>();
            var rawData = data.Where(item => item.BetType == criteria.BetType).OrderBy(o => o.GameTime);
            var groups = rawData.GroupBy(g => g.GameTime);
            var ticketList = new List<BetTypeLevelModel>();
            foreach (var group in groups)
            {
                var gameTime = group.DynamicSum();
                var groupedOutComes = group.GroupBy(item => item.OutCome);
                foreach (var outCome in groupedOutComes)
                {
                    var item = outCome.DynamicSum();
                    gameTime.ChildItems.Add(item);
                }
                ticketList.Add(gameTime);
            }

            result.TicketList = ticketList;
            result.TotalTicket = rawData.DynamicSum();
            result.Total = rawData.Count();
            return result;
        }
    }
}
