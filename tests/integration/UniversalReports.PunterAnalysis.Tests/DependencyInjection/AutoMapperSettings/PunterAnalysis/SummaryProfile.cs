using AutoMapper;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.AutoMapperSettings.PunterAnalysis
{
    public class SummaryProfile : Profile
    {
        public SummaryProfile()
        {
            CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            CreateMap<ReportModelBase<SummaryModel>, ViewModelJson>(MemberList.Source);
        }
    }
}
