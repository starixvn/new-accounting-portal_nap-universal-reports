using System.Web.Http;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Products
{
    [RoutePrefix("api/company-win-loss/product")]
    public class ProductController : ApiController
    {
        private readonly Service service;
        private readonly GridOptionService gridOptionService;

        public ProductController(Service service, GridOptionService gridOptionService)
        {
            this.service = service;
            this.gridOptionService = gridOptionService;
        }

        [Route("")]
        public IHttpActionResult Values(ProductWinLossQuery query)
        {
            if (ModelState.IsValid)
            {
                var criteria = new Criteria
                {
                    StartDate = query.StartDate,
                    EndDate = query.EndDate
                };
                var winlosses = service.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses);

                return Json(gridOptions);
            }

            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ProductWinLossQuery query)
        {
            if (ModelState.IsValid)
            {
                var criteria = new Criteria
                {
                    StartDate = query.StartDate,
                    EndDate = query.EndDate
                };
                var winlosses = service.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses);
                return new FanexExcelResult(gridOptions);
            }

            return null;
        }
    }
}