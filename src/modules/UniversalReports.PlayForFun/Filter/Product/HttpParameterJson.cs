using System.Collections.Generic;
using MediatR;

namespace UniversalReports.PlayForFun.Filter.Product
{
    public class HttpParameterJson : IRequest<IEnumerable<ProductEntity>>
    {
    }
}