using System.Web.Http;

namespace UniversalReports.NG2Statistics.Filter
{
    [RoutePrefix("api/ng2-statistics/filter")]
    public class FilterController : ApiController
    {
        private readonly Service service;

        public FilterController(Service service)
        {
            this.service = service;
        }

        [Route("sports")]
        public IHttpActionResult Sports()
        {
            var criteria = new SportCriteria();
            var sports = service.QuerySports(criteria);
            return Json(sports);
        }

        [Route("usernamesuggestion")]
        [HttpGet]
        public IHttpActionResult UsernameSuggestion(string userName)
        {
            var criteria = new UserSearchCriteria
            {
                CustId = 8,
                UserName = userName
            };
            var sports = service.QueryUserNames(criteria);
            return Json(sports);
        }

        [Route("currencies")]
        public IHttpActionResult Currencies()
        {
            var criteria = new CurrencyCriteria();
            var currencies = service.QueryCurrency(criteria);
            return Json(currencies);
        }
    }
}
