using AutoMapper;

namespace UniversalReports.Sites.AutoMapperSettings
{
    public static class AutoMapperSettingsRegistration
    {
        public static void Register()
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
                cfg.AddProfile<PlayForFunSummaryProfile>();
                cfg.AddProfile<PlayForFunDetailProfile>();
                cfg.AddProfile<PlayForFunFilterProfile>();
            });
        }
    }
}