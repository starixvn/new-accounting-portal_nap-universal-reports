using Fanex.NAP.Core.Models;
using Fanex.NAP.Core.Models.ParameterObject;
using Fanex.NAP.Core.Service.Interface;
using Fanex.NAP.Core.Web.Auth;
using Fanex.NAP.Core.Web.Context;
using Fanex.NAP.Core.Web.Session;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UniversalReports.Sites.Controllers
{
    public class FakeLoginController : Controller
    {
        private const int SiteId = 98;
        private readonly IUserService userService;
        private readonly ISecurityService securityService;
        private readonly ICurrentSession currentSession;
        private readonly ICurrentContext currentContext;

        public FakeLoginController(
             IUserService userService,
             ISecurityService securityService,
             ICurrentSession currentSession,
             ICurrentContext currentContext)
        {
            this.userService = userService;
            this.securityService = securityService;
            this.currentSession = currentSession;
            this.currentContext = currentContext;
        }

#if DEBUG

        [AllowAnonymous]
        public ActionResult Index()
        {
            const string Username = "sa";
            var user = userService.Get(Username);

            var userLoginId = CheckInUser(user);

            SaveCurrentSession(user, userLoginId);
            CreateAuthenticationTicket(user);

            return View(user);
        }

#endif

        private int CheckInUser(User user)
        {
            var loginParameter = new LoginParameter
            {
                UserId = user.Id,
                SiteId = SiteId,
                NetSessionId = Session.SessionID,
                Ip = currentContext.IP,
                LoginDate = DateTime.Now,
                BrowserName = currentContext.BrowserName,
                CountryCode = currentContext.CountryCode,
                Domain = currentContext.DomainName,
                Platform = currentContext.Platform
            };

            return securityService.Login(loginParameter);
        }

        private void SaveCurrentSession(User user, int userLoginId)
        {
            currentSession.Level = userService.GetUserLevel(user.Id, SiteId);
            currentSession.UserId = user.Id;
            currentSession.Username = user.Username;
            currentSession.OnUserId = userLoginId;
            currentSession.SessionId = Session.SessionID;
            currentSession.MenuItemList = userService.GetMenuItem(user.Id, SiteId, isActive: true).ToList();
        }

        private void CreateAuthenticationTicket(User user)
        {
            var authInfo = new AuthInfo
            {
                UserId = user.Id,
                OnUserId = currentSession.OnUserId
            };

            var authTicket = new FormsAuthenticationTicket(
                 1,
                user.Username,
                DateTime.Now,
                DateTime.Now + FormsAuthentication.Timeout,
                false,
                authInfo.ToXml(),
                "/");

            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            {
                HttpOnly = true,
                Path = "/",
                Name = FormsAuthentication.FormsCookieName
            };

            Response.Cookies.Add(authCookie);
        }
    }
}