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
            if (session.MenuItemList == null || session.MenuItemList.Count == 0)
            {
                return Json(GetFakeMenu());
            }

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
                        })
                        .ToList();
        }

        private List<Menu> GetFakeMenu()
        {
            var mainMenu = new Menu
            {
                Url = string.Empty,
                Name = "Main",
                Children = new List<Menu>
                {
                    new Menu { Url = "/Main/DailyWinLoss2h/Index", Name = "Daily Win Loss (2h)" },
                    new Menu { Url = "/UniversalReports/CompanyWinLoss", Name = "Company Win Loss By Products" }
                }
            };

            var balanceMenu = new Menu
            {
                Url = string.Empty,
                Name = "Balance",
                Children = new List<Menu>
                {
                    new Menu { Url = "/Balance/DirectBalance/Index", Name = "Direct Balance" }
                }
            };

            return new List<Menu> { mainMenu, balanceMenu };
        }
    }
}
