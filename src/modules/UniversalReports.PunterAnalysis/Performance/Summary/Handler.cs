using Fanex.Data.Repository;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Performance.Summary.Model;

namespace UniversalReports.PunterAnalysis.Performance.Summary
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, ViewModel>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ViewModel> Handle(HttpParameterJson message)
        {
            throw new System.Exception();
        }
    }
}