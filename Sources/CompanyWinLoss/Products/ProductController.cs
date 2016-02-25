using System.Web.Http;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class ProductController : ApiController
    {
        private readonly Service service;
        private readonly GridOptionService gridOptionService;

        public ProductController(Service service, GridOptionService gridOptionService)
        {
            this.service = service;
            this.gridOptionService = gridOptionService;
        }

        [Route("api/company-win-loss/values")]
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
    }
}