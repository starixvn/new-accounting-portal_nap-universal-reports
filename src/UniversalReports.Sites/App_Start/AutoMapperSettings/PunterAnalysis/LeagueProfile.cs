using AutoMapper;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.Sites.AutoMapperSettings.PunterAnalysis
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