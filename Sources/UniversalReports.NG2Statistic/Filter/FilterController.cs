using Fanex.NAP.Core.Web.Session;
using System.Web.Http;

namespace UniversalReports.NG2Statistic.Filter
{
    [RoutePrefix("api/ng2-statistic/filter")]
    public class FilterController : ApiController
    {
        private readonly Service service;
        private readonly ICurrentSession session;

        public FilterController(Service service, ICurrentSession session)
        {
            this.service = service;
            this.session = session;
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
            var criteria = new UserSearchCriteria()
            {
                CustId = 8,
                UserName = userName,
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
