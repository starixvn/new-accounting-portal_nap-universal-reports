using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.Summary
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, ViewModelJson>
    {
        private readonly IMapper mapper;

        private readonly PunterAnalysisService punterAnalysisService;

        public Handler(IMapper mapper, PunterAnalysisService punterAnalysisService)
        {
            this.mapper = mapper;
            this.punterAnalysisService = punterAnalysisService;
        }

        public async Task<ViewModelJson> Handle(HttpParameterJson message)
        {
            var criteria = mapper.Map<Criteria>(message);
            var model = await punterAnalysisService.Query<SummaryModel>(criteria);

            var viewModel = mapper.Map<ViewModelJson>(model);

            return viewModel;
        }
    }
}
