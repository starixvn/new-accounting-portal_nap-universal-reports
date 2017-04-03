using MediatR;
using System.Collections.Generic;

namespace UniversalReports.PunterAnalysis.Filter.ProductSportBetType
{
    public class HttpParameterJson : IRequest<IEnumerable<ProductSportBetTypeEntity>>
    {
    }
}
