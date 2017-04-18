using AutoMapper;
using LeagueFilter = UniversalReports.PunterAnalysis.Filter.League;
using ProductSportBetTypeFilter = UniversalReports.PunterAnalysis.Filter.ProductSportBetType;
using UsernameSuggestionFilter = UniversalReports.PunterAnalysis.Filter.UsernameSuggestion;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.AutoMapperSettings
{
    public class PunterAnalysisFilterProfile : Profile
    {
        public PunterAnalysisFilterProfile()
        {
            CreateMap<LeagueFilter.HttpParameterJson, LeagueFilter.QueryCriteria>(MemberList.Source);
            CreateMap<ProductSportBetTypeFilter.HttpParameterJson, ProductSportBetTypeFilter.QueryCriteria>(MemberList.Source);
            CreateMap<UsernameSuggestionFilter.HttpParameterJson, UsernameSuggestionFilter.QueryCriteria>(MemberList.Source);
        }
    }
}
