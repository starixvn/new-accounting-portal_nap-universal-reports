using AutoMapper;
using ProductFilter = UniversalReports.PlayForFun.Filter.Product;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection.AutoMapperSettings
{
    public class PlayForFunFilterProfile : Profile
    {
        public PlayForFunFilterProfile()
        {
            CreateMap<ProductFilter.HttpParameterJson, ProductFilter.Criteria>(MemberList.Source);
        }
    }
}