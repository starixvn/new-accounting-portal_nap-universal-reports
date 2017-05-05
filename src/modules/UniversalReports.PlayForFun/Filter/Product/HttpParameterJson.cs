using MediatR;
using System.Collections.Generic;

namespace UniversalReports.PlayForFun.Filter.Product
{
    public class HttpParameterJson : IRequest<IEnumerable<ProductEntity>>
    {
    }
}
