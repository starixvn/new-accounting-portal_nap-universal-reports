using AutoMapper;
using LeagueFilter = UniversalReports.PunterAnalysis.Filter.League;
using ProductSportBetTypeFilter = UniversalReports.PunterAnalysis.Filter.ProductSportBetType;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.AutoMapperSettings.PunterAnalysis
{
    public class FilterProfile : Profile
    {
        public FilterProfile()
        {
            CreateMap<LeagueFilter.HttpParameterJson, LeagueFilter.QueryCriteria>(MemberList.Source);
            CreateMap<ProductSportBetTypeFilter.HttpParameterJson, ProductSportBetTypeFilter.QueryCriteria>(MemberList.Source);
        }
    }
}
