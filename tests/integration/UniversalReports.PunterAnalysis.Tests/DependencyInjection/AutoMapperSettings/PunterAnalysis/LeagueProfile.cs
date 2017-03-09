using AutoMapper;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.AutoMapperSettings.PunterAnalysis
{
    public class LeagueProfile : Profile
    {
        public LeagueProfile()
        {
            CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            CreateMap<ReportModel, ViewModelJson>(MemberList.Source);
        }
    }
}
