using AutoMapper;
using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversalReports.SMAWinLoss.VirtualRate
{
    public interface VirtualRateService
    {
        Task<IEnumerable<VirtualRateModel>> GetVirtualRate(VirtualRateHttpParameter parameter);
    }

    public class VirtualRateServiceImp : VirtualRateService
    {
        private readonly IDynamicRepository repository;

        public VirtualRateServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<VirtualRateModel>> GetVirtualRate(VirtualRateHttpParameter parameter)
        {
            var criteria = Mapper.Map<VirtualRateCriteria>(parameter);
            return await repository.FetchAsync<VirtualRateModel>(criteria);
        }
    }
}