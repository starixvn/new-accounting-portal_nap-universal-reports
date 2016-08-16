using Fanex.NAP.Core.Model;
using Fanex.NAP.Core.Web.Session;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

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
            var isLocal = System.Web.HttpContext.Current.Request.IsLocal;
            if (isLocal)
            {
                return new Header
                {
                    Menus = GetFakeMenus()
                };
            }

            var sessionMenus = currentSession.MenuItemList ?? new List<MenuItem>();
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

        private List<Menu> GetFakeMenus()
        {
            var mainMenu = new Menu
            {
                Link = string.Empty,
                Name = "Main",
                Children = new List<Menu>
                {
                    new Menu { Link = "/Main/DailyWinLoss2h/Index", Name = "Daily Win Loss (2h)" },
                    new Menu { Link = "/UniversalReports/CompanyWinLoss", Name = "Company Win Loss By Products" }
                }
            };

            var balanceMenu = new Menu
            {
                Link = string.Empty,
                Name = "Balance",
                Children = new List<Menu>
                {
                    new Menu { Link = "/Balance/DirectBalance/Index", Name = "Direct Balance" }
                }
            };

            var legendMenu = new Menu
            {
                Link = "/LegendManagement",
                Name = "Legend Management"
            };

            return new List<Menu> { mainMenu, legendMenu, balanceMenu };
        }
    }
}