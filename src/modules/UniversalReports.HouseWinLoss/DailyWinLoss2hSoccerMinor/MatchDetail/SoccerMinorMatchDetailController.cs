using AutoMapper;
using Fanex.Excel.Models;
using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.MatchDetail;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.MatchDetail
{
    using Results;

    [RoutePrefix("api/house-win-loss-by-products/soccer-minor/match-detail")]
    public class SoccerMinorMatchDetailController : ApiController
    {
        private readonly WinLossService service;

        private readonly GridOptionsBuilder builder;

        private readonly SoccerMinorMatchGridOptionColumnDecorator decorator;

        private readonly MatchSortingService sortingService;

        public SoccerMinorMatchDetailController(
            WinLossService service,
            GridOptionsBuilder builder,
            SoccerMinorMatchGridOptionColumnDecorator decorator,
            MatchSortingService sortingService)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
            this.sortingService = sortingService;
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<UniversalSportbookMatchDetailCriteria>(queryModel);
            var gridOptions = GetGridOptions(criteria, string.Empty, queryModel.SortColumnName, queryModel.SortDirection);
            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<UniversalSportbookMatchDetailCriteria>(queryModel);
            var gridOptions = GetGridOptions(criteria, queryModel.Title, queryModel.SortColumnName, queryModel.SortDirection);
            return new FanexExcelResult(gridOptions, Constants.SoccerMinorBetTypesSheetName);
        }

        private GridOptions GetGridOptions(WinLossCriteria criteria, string title, string sortColumnName, string sortDirection)
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

            winlosses = sortingService.SortData(winlosses, sortDirection, sortColumnName);

            var gridOptions = builder.Build(winlosses, title);
            return decorator.Build(gridOptions, sortColumnName, sortDirection);
        }
    }
}