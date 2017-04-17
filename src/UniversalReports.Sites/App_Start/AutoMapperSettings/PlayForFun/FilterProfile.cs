using AutoMapper;
using ProductFilter = UniversalReports.PlayForFun.Filter.Product;

namespace UniversalReports.Sites.AutoMapperSettings.PlayForFun
{
    public class FilterProfile : Profile
    {
        public FilterProfile()
        {
            CreateMap<ProductFilter.HttpParameterJson, ProductFilter.Criteria>(MemberList.Source);
        }
    }
}