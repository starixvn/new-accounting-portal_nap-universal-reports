using Fanex.Data.Repository;
using Linq.DynamicSum;
using System.Threading.Tasks;
using UniversalReports.BetConstructPerformance.Criteria;
using UniversalReports.BetConstructPerformance.Models;

namespace UniversalReports.BetConstructPerformance.Services
{
    public interface BetConstructPerformanceService
    {
        Task<SportModel> GetSports(SportCriteria criteria);
    }

    public class BetConstructPerformanceServiceImp : BetConstructPerformanceService
    {
        private readonly IDynamicRepository repository;

        public BetConstructPerformanceServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public Task<SportModel> GetSports(SportCriteria criteria)
        {
            var rawData = repository.Fetch<SportItemModel>(criteria);
            var data = new SportModel
            {
                Items = rawData,
                Total = rawData.DynamicSum()
            };
            return Task.FromResult(data);
        }
    }
}
