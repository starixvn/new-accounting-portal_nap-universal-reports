using AutoMapper;

namespace UniversalReports.Sites.MediatorInjector.PunterAnalysis
{
    public static class PunterAnalysisAutoMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<SummaryProfile>();
                cfg.AddProfile<BetTypeProfile>();
            });
        }
    }
}
