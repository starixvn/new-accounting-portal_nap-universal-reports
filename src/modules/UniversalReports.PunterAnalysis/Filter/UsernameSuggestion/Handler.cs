using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Fanex.Data.Repository;
using Fanex.NAP.Core.Web.Session;
using MediatR;

namespace UniversalReports.PunterAnalysis.Filter.UsernameSuggestion
{
    public class Handler : IRequestHandler<HttpParameterJson, IEnumerable<string>>
    {
        private readonly IDynamicRepository repository;

        private readonly ICurrentSession currentSession;

        public Handler(ICurrentSession currentSession, IDynamicRepository repository)
        {
            this.repository = repository;
            this.currentSession = currentSession;
        }

        public async Task<IEnumerable<string>> Handle(HttpParameterJson request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<QueryCriteria>(request);
            criteria.CustId = currentSession.UserId;
            return await repository.FetchAsync<string>(criteria);
        }
    }
}