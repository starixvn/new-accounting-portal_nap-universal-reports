using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Common.SiteWinLoss
{
    public abstract class SiteWinLossController : ApiController
    {
        protected SiteWinLossController()
        {
        }

        protected SiteWinLossController(WinLossService service, GridOptionsBuilder builder, GridOptionColumnDecorator decorator)
        {
            Service = service;
            Builder = builder;
            Decorator = decorator;
        }

        private WinLossService Service { get; }

        private GridOptionsBuilder Builder { get; }

        private GridOptionColumnDecorator Decorator { get; }

        protected IHttpActionResult Json(WinLossCriteria criteria, string site)
        {
            var winlosses = Service.Query(criteria);
            var gridOptions = Builder.Build(winlosses, string.Empty);
            gridOptions = Decorator.Build(gridOptions, site);

            return Json(gridOptions);
        }

        protected IHttpActionResult Excel(WinLossCriteria criteria, string site, string title)
        {
            var winlosses = Service.Query(criteria);
            var gridOptions = Builder.Build(winlosses, title);
            gridOptions = Decorator.Build(gridOptions, site);

            return new FanexExcelResult(gridOptions, Constants.SheetName);
        }
    }
}
