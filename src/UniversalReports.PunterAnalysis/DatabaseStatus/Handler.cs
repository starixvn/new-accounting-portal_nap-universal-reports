using AutoMapper;
using Fanex.Data.Repository;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.DatabaseStatus.Model;

namespace UniversalReports.PunterAnalysis.DatabaseStatus
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, bool>
    {
        private readonly IMapper mapper;

        private readonly IDynamicRepository repository;

        public Handler(IMapper mapper, IDynamicRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<bool> Handle(HttpParameterJson message)
        {
            var criteria = new Criteria();
            var status = await repository.GetAsync<int>(criteria);
            return status > 0;
        }
    }
}
