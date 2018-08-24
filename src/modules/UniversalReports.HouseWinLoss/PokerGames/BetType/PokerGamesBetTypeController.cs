using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.PokerGames.BetType
{
    [RoutePrefix("api/house-win-loss-by-products/poker-games")]
    public class PokerGamesBetTypeController : BasicWinLossController
    {
        public PokerGamesBetTypeController(BasicWinLossService service, BasicGridOptionsBuilder builder, GridOptionColumnDecoratorBasic decorator)
         : base(service, builder, decorator)
        {
        }

        [Route("bet-type")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Json(criteria, "Bet Type");
        }

        [Route("bet-type/excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Excel(criteria, "Bet Type", queryModel.Title);
        }
    }
}