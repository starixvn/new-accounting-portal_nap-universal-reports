using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Common.SiteWinLoss
{
    public class SiteWinLossController : ApiController
    {
        private readonly WinLossService service;

        private readonly GridOptionsBuilder builder;

        private readonly GridOptionColumnDecorator decorator;

        public SiteWinLossController(WinLossService service, GridOptionsBuilder builder, GridOptionColumnDecorator decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        protected IHttpActionResult Json(WinLossCriteria criteria, string site)
        {
            var winlosses = service.Query(criteria);
            var gridOptions = builder.Build(winlosses, string.Empty);
            gridOptions = decorator.Build(gridOptions, site);

            return Json(gridOptions);
        }

        protected IHttpActionResult Excel(WinLossCriteria criteria, string site, string title, string sheetName)
        {
            var winlosses = service.Query(criteria);
            var gridOptions = builder.Build(winlosses, title);
            gridOptions = decorator.Build(gridOptions, site);

            return new FanexExcelResult(gridOptions, sheetName);
        }
    }
}