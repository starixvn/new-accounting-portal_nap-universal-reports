using AutoMapper;
using Fanex.Data.Repository;
using Fanex.NAP.Core.Web.Session;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Filter.UsernameSuggestion
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, IEnumerable<string>>
    {
        private readonly IMapper mapper;

        private readonly IDynamicRepository repository;

        private readonly ICurrentSession currentSession;

        public Handler(IMapper mapper, ICurrentSession currentSession, IDynamicRepository repository)
        {
            this.repository = repository;
            this.currentSession = currentSession;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<string>> Handle(HttpParameterJson message)
        {
            var criteria = mapper.Map<QueryCriteria>(message);
            criteria.CustId = currentSession.UserId;
            return await repository.FetchAsync<string>(criteria).ConfigureAwait(false);
        }
    }
}
