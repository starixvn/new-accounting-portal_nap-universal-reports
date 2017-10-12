using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Fanex.NAP.Core.Models;
using Fanex.NAP.Core.Web.Session;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace UniversalReports.Application.Header
{
    public class HeaderController : ApiController
    {
        private readonly ICurrentSession currentSession;

        public HeaderController(ICurrentSession currentSession)
        {
            this.currentSession = currentSession;
        }

        [Route("api/application/header")]
        public Header Index()
        {
            var sessionMenus = currentSession.MenuItemList ?? new List<MenuItem>();
            var menus = GetMenus(sessionMenus);
            return new Header
            {
                Username = currentSession.Username,
                Menus = menus
            };
        }

        [Route("state-api/application/header")]
        [HttpPost]
        public IHttpActionResult Header()
        {
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var sessionMenus = currentSession.MenuItemList ?? new List<MenuItem>();
            var menus = GetMenus(sessionMenus);
            return Json(new Header
            {
                Username = currentSession.Username,
                Menus = menus
            }, serializerSettings);
        }

        private List<Menu> GetMenus(IList<MenuItem> menus)
        {
            return menus.Where(m => m.Parent == null)
                               .OrderBy(m => m.DisplayOrder)
                               .Select(m => new Menu
                               {
                                   Id = m.Id,
                                   Name = m.Name,
                                   Link = m.Url,
                                   Children = GetChildrenMenus(menus, m.Id)
                               })
                               .ToList();
        }

        private List<Menu> GetChildrenMenus(IEnumerable<MenuItem> menus, int parentMenuId)
        {
            return menus.Where(x => x.Parent?.Id == parentMenuId)
                        .OrderBy(m => m.DisplayOrder)
                        .Select(m => new Menu
                        {
                            Id = m.Id,
                            Name = m.Name,
                            Link = m.Url
                        })
                        .ToList();
        }
    }
}