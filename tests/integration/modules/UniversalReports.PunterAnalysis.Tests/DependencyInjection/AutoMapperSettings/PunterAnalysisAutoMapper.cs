using AutoMapper;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.AutoMapperSettings
{
    public static class PunterAnalysisAutoMapper
    {
        public static void Initialize()
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
        }
    }
}
