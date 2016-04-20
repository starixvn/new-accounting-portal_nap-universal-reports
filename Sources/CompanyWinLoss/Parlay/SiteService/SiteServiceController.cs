using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Parlay.SiteService
{
    public abstract class SiteServiceController : ApiController
    {
        protected SiteServiceController()
        {
        }

        protected SiteServiceController(SiteWinLossService service, GridOptionBuilderSite builder, GridOptionColumnDecorator decorator)
        {
            Service = service;
            Builder = builder;
            Decorator = decorator;
        }

        private SiteWinLossService Service { get; }

        private GridOptionBuilderSite Builder { get; }

        private GridOptionColumnDecorator Decorator { get; }

        protected IHttpActionResult Json(WinLossCriteria criteria, string site)
        {
            if (ModelState.IsValid)
            {
                var winlosses = Service.Query(criteria);
                var gridOptions = Builder.Build(winlosses, string.Empty);
                gridOptions = Decorator.Build(gridOptions, site);

                return Json(gridOptions);
            }

            return null;
        }

        protected IHttpActionResult Excel(WinLossCriteria criteria, string site, string title)
        {
            if (ModelState.IsValid)
            {
                var winlosses = Service.Query(criteria);
                var gridOptions = Builder.Build(winlosses, title);
                gridOptions = Decorator.Build(gridOptions, site);

                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}
