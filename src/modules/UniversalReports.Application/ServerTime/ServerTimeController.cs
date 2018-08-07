using System;
using System.Web.Http;

namespace UniversalReports.Application.ServerTime
{
    public class ServerTimeController : ApiController
    {
        [Route("state-api/application/today")]
        [HttpPost]
        public IHttpActionResult Today()
        {
            return Json(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day));
        }
    }
}
