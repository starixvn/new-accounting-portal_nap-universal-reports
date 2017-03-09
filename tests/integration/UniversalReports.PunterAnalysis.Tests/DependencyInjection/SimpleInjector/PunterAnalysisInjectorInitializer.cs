using SimpleInjector;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.AssociatedAccount;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.League;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.SimpleInjector
{
    internal static class PunterAnalysisInjectorInitializer
    {
        internal static Container RegisterPunterAnalysisServices(this Container container)
        {
            container.Register<PunterAnalysisService, PunterAnalysisServiceImp>();
            container.Register<DateTimeService, DateTimeServiceImp>();
            container.Register<LeagueServiceFactory, LeagueServiceFactoryImp>();
            container.Register<FraudServiceWrapper, FraudServiceWrapperImp>();
            container.Register<ApplicationConfigurationService, ApplicationConfigurationServiceImp>();

            return container;
        }
    }
}