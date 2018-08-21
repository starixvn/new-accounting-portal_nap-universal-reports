using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.Sites.Controllers
{
    [RoutePrefix("api/test")]
    public class TestApiController : ApiController
    {
        [Route("sleep")]
        public async Task<IHttpActionResult> Index()
        {
            await Task.Delay(5000).ConfigureAwait(false);
            return Json("OK");
        }
    }
}