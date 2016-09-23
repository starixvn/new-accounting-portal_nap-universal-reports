using Fanex.Repository;
using System.Web.Http;
using Fanex.NAP.Core.Web.Session;

namespace UniversalReports.NG2Statistic.Filter
{
    [RoutePrefix("api/ng2-statistic/filter")]
    public class FilterController : ApiController
    {
        private readonly Service service;
        private readonly ICurrentSession session;

        public FilterController(Service service)
        {
            this.service = service;
        }

        [Route("sports")]
        public IHttpActionResult Sports()
        {
            var criteria = new SportCriteria();
            var sports = service.Query(criteria);
            return Json(sports);
        }

        [Route("currencies")]
        public IHttpActionResult Currencies()
        {
            var criteria = new CurrencyCriteria();            
            //var currencies = repository.Fetch<Entity>(criteria);
            //return Json(currencies);

            return null;
        }
    }
}
