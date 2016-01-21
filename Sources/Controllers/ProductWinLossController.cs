using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using System.Web.Http;

namespace NAP.Reports.CompanyWinLoss.Controllers
{
    public class ProductWinLossController : ApiController
    {
        private ProductWinLossService _service;

        public ProductWinLossController(ProductWinLossService service)
        {
            _service = service;
        }

        public ProductWinLoss Values(ProductWinLossQuery query)
        {
            var criteria = new ProductWinLossCriteria
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
