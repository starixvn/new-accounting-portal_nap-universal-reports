using AutoMapper;

namespace UniversalReports.Sites.AutoMapperSettings.PunterAnalysis
{
    public static class PunterAnalysisAutoMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<SummaryProfile>();
                cfg.AddProfile<BetCountProfile>();
                cfg.AddProfile<BetTypeProfile>();
                cfg.AddProfile<SportTypeProfile>();
                cfg.AddProfile<AssociatedAccountProfile>();
                cfg.AddProfile<LeagueProfile>();
                cfg.AddProfile<FilterProfile>();
            });
        }
    }
}