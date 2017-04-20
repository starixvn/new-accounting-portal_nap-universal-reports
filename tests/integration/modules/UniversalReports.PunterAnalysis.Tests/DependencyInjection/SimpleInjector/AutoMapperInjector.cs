using AutoMapper;
using SimpleInjector;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection.AutoMapperSettings;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.SimpleInjector
{
    public static class AutoMapperInjector
    {
        public static Container RegisterAutoMapper(this Container container)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<PunterAnalysisSummaryProfile>();
                cfg.AddProfile<PunterAnalysisBetCountProfile>();
                cfg.AddProfile<PunterAnalysisBetTypeProfile>();
                cfg.AddProfile<PunterAnalysisSportTypeProfile>();
                cfg.AddProfile<PunterAnalysisAssociatedAccountProfile>();
                cfg.AddProfile<PunterAnalysisLeagueProfile>();
                cfg.AddProfile<PunterAnalysisFilterProfile>();
            });

            container.Register(() => Mapper.Instance);
            return container;
        }
    }
}
