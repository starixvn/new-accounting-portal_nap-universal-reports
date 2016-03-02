using Fanex.Excel.Models;
using Newtonsoft.Json;
using System.IO;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace UniversalReports.MVC.Filter
{
    public class JsonFilter : ActionFilterAttribute
    {
        public string Parameter { get; set; }

        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            if (filterContext.Request.Content.Headers.ContentType.MediaType.Contains("application/json"))
            {
                string inputContent;
                using (var stream = new StreamReader(filterContext.Request.Content.ReadAsStreamAsync().Result))
                {
                    stream.BaseStream.Position = 0;
                    inputContent = stream.ReadToEnd();
                }

                var result = JsonConvert.DeserializeObject<GridOptions>(inputContent);
                filterContext.ActionArguments[Parameter] = result;
            }
        }
    }
}
