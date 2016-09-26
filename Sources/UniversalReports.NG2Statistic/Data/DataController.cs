using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.NG2Statistic.Data
{
    [RoutePrefix("api/ng2-statistic/data")]
    public class DataController : ApiController
    {
        [Route("reportbydaily")]
        public IHttpActionResult Sports()
        {
            //var criteria = new SportCriteria();
            //var sports = service.QuerySports(criteria);
            //return Json(sports);

            return null;
        }
    }
}
