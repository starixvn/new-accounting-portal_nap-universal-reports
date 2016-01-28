using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class ProductController : ApiController
    {
        private readonly Service _service;

        public ProductController(Service service)
        {
            _service = service;
        }

        public ProductWinLoss Values(ProductWinLossQuery query)
        {
            var criteria = new Criteria
            {
                StartDate = query.StartDate,
                EndDate = query.EndDate
            };

            return ModelState.IsValid
                ? _service.Query(criteria)
                : null;
        }
    }
}
