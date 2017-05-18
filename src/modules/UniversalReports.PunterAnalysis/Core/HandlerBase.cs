using AutoMapper;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using MediatR;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Core
{
    public abstract class HandlerBase
    {
        private readonly IMapper mapper;

        private readonly PunterAnalysisService punterAnalysisService;

        protected HandlerBase(IMapper mapper, PunterAnalysisService punterAnalysisService)
        {
            this.mapper = mapper;
            this.punterAnalysisService = punterAnalysisService;
        }

        protected async Task<SummaryEntity<TModel>> Handle<TCriteria, TModel>(IRequest<SummaryEntity<TModel>> message)
            where TCriteria : ICriteria
            where TModel : class, new()
        {
            var criteria = mapper.Map<TCriteria>(message);
            return await punterAnalysisService.Query<TModel>(criteria);
        }
    }
}
