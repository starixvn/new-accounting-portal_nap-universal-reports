using Fanex.NAP.Core.Model;
using Fanex.NAP.Core.Web.Session;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace UniversalReports.Application.Header
{
    public class HeaderController : ApiController
    {
        private ICurrentSession currentSession;

        public HeaderController(ICurrentSession currentSession)
        {
            this.currentSession = currentSession;
        }

        [Route("api/application/header")]
        public Header Index()
        {
            if (currentSession.MenuItemList == null || currentSession.MenuItemList.Count == 0)
            {
                return new Header
                {
                    Menus = GetFakeMenu()
                };
            }

            var sessionMenus = currentSession.MenuItemList == null ? new List<MenuItem>() : currentSession.MenuItemList;
            var menus = GetMenus(sessionMenus);
            return new Header
            {
                Username = currentSession.Username,
                Menus = menus
            };
        }

        private List<Menu> GetMenus(IList<MenuItem> menus)
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

            var legendMenu = new Menu
            {
                Url = "/LegendManagement",
                Name = "Legend Management"
            };

            return new List<Menu> { mainMenu, legendMenu, balanceMenu };
        }
    }
}