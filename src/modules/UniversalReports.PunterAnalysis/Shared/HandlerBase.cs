using AutoMapper;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using MediatR;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Shared
{
    public class HandlerBase
    {
        private readonly PunterAnalysisService punterAnalysisService;

        protected HandlerBase(PunterAnalysisService punterAnalysisService)
        {
            this.punterAnalysisService = punterAnalysisService;
        }

        protected async Task<SummaryEntity<TModel>> Handle<TCriteria, TModel>(IRequest<SummaryEntity<TModel>> message)
            where TCriteria : ICriteria
            where TModel : class, new()
        {
            var criteria = Mapper.Map<TCriteria>(message);
            return await punterAnalysisService.Query<TModel>(criteria).ConfigureAwait(false);
        }
    }
}
