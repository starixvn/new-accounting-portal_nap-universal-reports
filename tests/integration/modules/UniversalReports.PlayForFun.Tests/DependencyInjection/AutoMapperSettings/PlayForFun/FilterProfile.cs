using AutoMapper;
using ProductFilter = UniversalReports.PlayForFun.Filter.Product;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection.AutoMapperSettings.PlayForFun
{
    public class FilterProfile : Profile
    {
        public FilterProfile()
        {
            CreateMap<ProductFilter.HttpParameterJson, ProductFilter.Criteria>(MemberList.Source);
        }
    }
}