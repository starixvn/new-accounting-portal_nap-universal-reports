using Fanex.Repository;
using System.Web.Http;

namespace UniversalReports.NG2Statistic.Filter
{
    [RoutePrefix("api/ng2-statistic/filter")]
    public class FilterController : ApiController
    {
        private readonly SimpleRepository repository;

        public FilterController(SimpleRepository repository)
        {
            this.repository = repository;
        }

        [Route("sports")]
        public IHttpActionResult Sports()
        {
            var criteria = new SportCriteria();
            var sports = repository.Fetch<Entity>(criteria);
            return Json(sports);
        }

        [Route("currencies")]
        public IHttpActionResult Currencies()
        {
            var criteria = new CurrencyCriteria();
            var currencies = repository.Fetch<Entity>(criteria);
            return Json(currencies);
        }
    }
}
