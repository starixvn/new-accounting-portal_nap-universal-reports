using AutoMapper;
using ProductFilter = UniversalReports.PlayForFun.Filter.Product;

namespace UniversalReports.Sites.AutoMapperSettings
{
    public class PlayForFunFilterProfile : Profile
    {
        public PlayForFunFilterProfile()
        {
            CreateMap<ProductFilter.HttpParameterJson, ProductFilter.Criteria>(MemberList.Source);
        }
    }
}