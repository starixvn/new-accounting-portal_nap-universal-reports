using System.Collections.Generic;
using MediatR;

namespace UniversalReports.PunterAnalysis.Filter.ProductSportBetType
{
    public class HttpParameterJson : IRequest<IEnumerable<ProductSportBetTypeEntity>>
    {
    }
}