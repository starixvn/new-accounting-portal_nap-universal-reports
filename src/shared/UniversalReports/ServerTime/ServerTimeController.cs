namespace UniversalReports.ServerTime
{
    using System;
    using System.Web.Http;

    public class ServerTimeController : ApiController
    {
        [Route("state-api/application/today")]
        [HttpPost]
        public IHttpActionResult Today()
        {
            return Json(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day));
        }

        [Route("state-api/application/server-time")]
        [HttpPost]
        public IHttpActionResult ServerTime()
        {
            return Json(DateTime.Now);
        }
    }
}
