using System.Net;
using System.Web.Http;

namespace UniversalReports.Application.Menu
{
    public class LegendController : ApiController
    {
        [Route("api/application/legend")]
        public IHttpActionResult Values()
        {
            return Content(HttpStatusCode.OK, "XYZ");
        }
    }
}