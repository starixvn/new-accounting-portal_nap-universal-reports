using AutoMapper;
using Fanex.NAP.Core;
using System;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using UniversalReports.AbnormalBet;
using UniversalReports.ActualMemberBet;
using UniversalReports.CN88WinLoss;
using UniversalReports.Exchange;
using UniversalReports.HouseWinLoss;
using UniversalReports.NG2Statistics;
using UniversalReports.PunterAnalysis;
using UniversalReports.SBCustomerPerformanceByDanger;
using UniversalReports.SBPerformance;
using UniversalReports.Sites.App_Start;
using UniversalReports.SMAWinLoss;
using UniversalReports.UpdatedUsernameCredit;
using UniversalReports.VoidingSettledTickets;
using UniversalReports.CashOutPerformance;

namespace UniversalReports.Sites
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ChangeApplicationName();
            RemotingRef.Register();
            FanexData.Register();
            FanexLogging.Register();
            OnebookUMInitializer.InitializeUMClientManager();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mapper.Initialize(cfg =>
            {
                cfg.InitializeHouseWinLoss();
                cfg.InitializeNG2Statistics();
                cfg.InitializePunterAnalysis();
                cfg.InitializeUpdatedUsernameCredit();
                cfg.InitializeExchange();
                cfg.InitializeActualMemberBet();
                cfg.InitializeCN88WinLoss();
                cfg.InitializeAbnormalBet();
                cfg.InitializeSBPerformance();
                cfg.InitializeSMAWinLoss();
                cfg.InitializeVoidingSettledTickets();
                cfg.InitializeSBCustomerPerformanceByDanger();
                cfg.InitializeCashOutPerformance();
            });
        }

        private static void ChangeApplicationName()
        {
            const string ApplicationName = "NAP_ACC_REPORT";

            // Change the Application Name in runtime.
            var runtimeInfo = typeof(HttpRuntime).GetField("_theRuntime", BindingFlags.Static | BindingFlags.NonPublic);
            var appNameInfo = typeof(HttpRuntime).GetField("_appDomainAppId", BindingFlags.Instance | BindingFlags.NonPublic);
            var theRuntime = runtimeInfo.GetValue(null);

            appNameInfo.SetValue(theRuntime, ApplicationName);
        }

        protected void Application_PostAuthorizeRequest()
        {
            var request = HttpContext.Current.Request;
            if (request.Url.ToString().Contains("api/application/header")
                || request.Url.ToString().Contains("api/punter-analysis/filter/username-suggestion")
                || request.Url.ToString().Contains("state-api/application/header")
                || request.Url.ToString().Contains("api/sb-performance/check-full-view")
                || request.Url.ToString().Contains("api/sma-win-loss/summary")
                || request.Url.ToString().Contains("api/cash-out-performance/common/check-full-view")
                || request.Url.ToString().Contains("api/sma-win-loss/filter/permission"))
            {
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.ReadOnly);
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            FanexLogging.HandleApplicationError(Server);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            if (HttpContext.Current != null)
            {
                SessionAuthenticationHandler.SignOutIfSessionIsInconsistent(HttpContext.Current);
            }
        }
    }
}