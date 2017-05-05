using Fanex.Data.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversalReports.PlayForFun.Filter.Product
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, IEnumerable<ProductEntity>>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ProductEntity>> Handle(HttpParameterJson message)
        {
            var criteria = new Criteria();
            return await repository.FetchAsync<ProductEntity>(criteria);
        }
    }
}
