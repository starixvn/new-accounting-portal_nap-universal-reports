using AutoMapper;
using Fanex.Excel.Models;
using System;
using System.Linq;
using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.BetType
{
    using Results;

    [RoutePrefix("api/house-win-loss-by-products/soccer-minor/bet-type")]
    public class SoccerMinorBetTypeController : ApiController
    {
        private readonly BasicWinLossService service;

        private readonly BasicGridOptionsBuilder builder;

        private readonly BettypeGridOptionColumnDecorator decorator;

        public SoccerMinorBetTypeController(
            BasicWinLossService service,
            BasicGridOptionsBuilder builder,
            BettypeGridOptionColumnDecorator decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            const int mainColumnWidth = 210;
            var gridOptions = GetGridOptions(criteria, "Bet Type", queryModel.SortColumnName, queryModel.SortDirection, string.Empty, mainColumnWidth);
            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            const int mainColumnWidth = 210;
            var gridOptions = GetGridOptions(criteria, "Bet Type", queryModel.SortColumnName, queryModel.SortDirection, queryModel.BetTypeFullTitle, mainColumnWidth);
            return new FanexExcelResult(gridOptions, Constants.SheetName);
        }

        private GridOptions GetGridOptions(Criteria criteria, string mainColumnText, string sortColumnName, string sortDirection, string title = "", int mainColumnWidth = 180)
        {
            var winlosses = service.Query(criteria);

            if (string.IsNullOrEmpty(sortColumnName))
            {
                sortColumnName = "RealIncome";
            }

            if (string.IsNullOrEmpty(sortDirection))
            {
                sortDirection = "desc";
            }

            SortData(winlosses, sortDirection, sortColumnName);

            var gridOptions = builder.Build(winlosses, title);
            return decorator.Build(gridOptions, mainColumnText, sortColumnName, sortDirection, mainColumnWidth);
        }

        private static void SortData(BasicWinLossModel winlosses, string sortDirection, string sortColumnName)
        {
            var propInfo = typeof(WinLoss).GetProperty(sortColumnName);
            var isAsc = string.Equals(sortDirection, SortingInformation.Ascending, StringComparison.OrdinalIgnoreCase);
            winlosses.SiteWinLossSummaries = isAsc ?
            winlosses
                .SiteWinLossSummaries
                .OrderBy(s => propInfo.GetValue(s.Total, null))
                .ToList() :
            winlosses
                 .SiteWinLossSummaries
                .OrderByDescending(s => propInfo.GetValue(s.Total, null))
                .ToList();
        }
    }
}