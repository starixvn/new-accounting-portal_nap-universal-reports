using Fanex.NAP.Core.Model;
using Fanex.NAP.Core.Web.Session;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace UniversalReports.Application.Menu
{
    public class MenuController : ApiController
    {
        [Route("api/application/menu")]
        public IHttpActionResult Values()
        {
            var session = new CurrentSession();
            var sessionMenus = session.MenuItemList == null ? new List<MenuItem>() : session.MenuItemList;
            var menus = GetMenu(sessionMenus);
            return Json(menus);
        }

        private List<Menu> GetMenu(IList<MenuItem> menus)
        {
            return menus.Where(m => m.Parent == null)
                               .OrderBy(m => m.DisplayOrder)
                               .Select(m => new Menu
                               {
                                   Name = m.Name,
                                   Url = m.Url,
                                   Children = GetChildrendMenu(menus, m.Id)
                               })
                               .ToList();
        }

        private List<Menu> GetChildrendMenu(IList<MenuItem> menus, int parentMenuId)
        {
            return menus.Where(x => x.Parent?.Id == parentMenuId)
                        .OrderBy(m => m.DisplayOrder)
                        .Select(m => new Menu
                        {
                            Name = m.Name,
                            Url = m.Url
                        }).
                        ToList();
        }
    }
}
