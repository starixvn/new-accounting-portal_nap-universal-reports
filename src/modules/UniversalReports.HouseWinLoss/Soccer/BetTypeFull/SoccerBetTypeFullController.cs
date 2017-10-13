using System.Collections.Generic;
using System.Web.Http;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Soccer.BetTypeFull
{
    [RoutePrefix("api/house-win-loss-by-products/soccer/bettype-full")]
    public class SoccerBetTypeFullController : ApiController
    {
        private readonly AbstractFactory factory;

        public SoccerBetTypeFullController(AbstractFactory factory)
        {
            this.factory = factory;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var betTypeFullGridOptionFactory = factory.CreateGridOptionFactory(queryModel.IsMajor, 2);
            var betTypeFullGridOptions = betTypeFullGridOptionFactory.CreateGridOption(queryModel, queryModel.BetTypeFullTitle, 2);

            var betTypeLiveGridOptionFactory = factory.CreateGridOptionFactory(queryModel.IsMajor, 1);
            var betTypeLiveGridOptions = betTypeLiveGridOptionFactory.CreateGridOption(queryModel, queryModel.BetTypeLiveTitle, 1);

            var betTypeNonLiveGridOptionFactory = factory.CreateGridOptionFactory(queryModel.IsMajor, 0);
            var betTypeNonLiveGridOptions = betTypeNonLiveGridOptionFactory.CreateGridOption(queryModel, queryModel.BetTypeNonLiveTitle, 0);

            return new FanexExcelResult(
                new List<GridOptions> { betTypeFullGridOptions, betTypeLiveGridOptions, betTypeNonLiveGridOptions },
                Constants.SheetName);
        }
    }
}