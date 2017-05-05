using AutoMapper;
using SimpleInjector;
using UniversalReports.Sites.AutoMapperSettings;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class AutoMapperInjector
    {
        internal static Container RegiserAutoMapper(this Container container)
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
                cfg.AddProfile<PunterAnalysisPerformanceProfile>();
                cfg.AddProfile<PlayForFunSummaryProfile>();
                cfg.AddProfile<PlayForFunDetailProfile>();
                cfg.AddProfile<PlayForFunFilterProfile>();
            });

            container.Register(() => Mapper.Instance);

            return container;
        }
    }
}