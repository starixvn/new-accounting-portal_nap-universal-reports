using MediatR;
using System.Collections.Generic;

namespace UniversalReports.PunterAnalysis.Filter.UsernameSuggestion
{
    public class HttpParameterJson : IRequest<IEnumerable<string>>
    {
        public string Username { get; set; }

        public int RoleId { get; set; }
    }
}
