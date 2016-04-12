using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.NumberGame.BetType
{
    [RoutePrefix("api/company-win-loss/number-game/bet-type")]
    public class NumberGameBetTypeController : ApiController
    {
        private readonly Service winlossService;
        private readonly BetTypeGridOptionService gridOptionService;

        public NumberGameBetTypeController(Service winlossService, BetTypeGridOptionService gridOptionService)
        {
            this.winlossService = winlossService;
            this.gridOptionService = gridOptionService;
        }

        [Route("")]
        public IHttpActionResult BetType(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = winlossService.Query(criteria);
                var liveBetTypeWinLoss = new BasicWinLossModel
                {
                    SiteWinLossSummaries = winlosses.Live,
                    GrandTotal = winlosses.LiveGrandTotal
                };
                var liveGridOptions = gridOptionService.FromWinLossModel(liveBetTypeWinLoss, string.Empty);

                var nonLiveBetTypeWinLoss = new BasicWinLossModel
                {
                    SiteWinLossSummaries = winlosses.NonLive,
                    GrandTotal = winlosses.NonLiveGrandTotal
                };

                var nonLiveGridOptions = gridOptionService.FromWinLossModel(nonLiveBetTypeWinLoss, string.Empty);

                return Json(new { Live = liveGridOptions, NonLive = nonLiveGridOptions });
            }

            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = winlossService.Query(criteria);
                var liveBetTypeWinLoss = new BasicWinLossModel
                {
                    SiteWinLossSummaries = winlosses.Live,
                    GrandTotal = winlosses.LiveGrandTotal
                };
                var liveGridOptions = gridOptionService.FromWinLossModel(liveBetTypeWinLoss, queryModel.LiveTitle);

                var nonLiveBetTypeWinLoss = new BasicWinLossModel
                {
                    SiteWinLossSummaries = winlosses.NonLive,
                    GrandTotal = winlosses.NonLiveGrandTotal
                };

                var nonLiveGridOptions = gridOptionService.FromWinLossModel(nonLiveBetTypeWinLoss, queryModel.NonLiveTitle);

                return new FanexExcelResult(new List<GridOptions> { nonLiveGridOptions, liveGridOptions }, Constants.SheetName);
            }

            return null;
        }
    }
}