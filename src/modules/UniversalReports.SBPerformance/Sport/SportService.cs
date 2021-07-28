using AutoMapper;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using System.Threading.Tasks;
using UniversalReports.SBPerformance.Common;

namespace UniversalReports.SBPerformance.Sport
{
    public interface SportService
    {
        Task<SummaryEntity<SportItemModel>> Query(SportHttpParameter parammeter);
    }

    public class SportServiceImp : SportService
    {
        private readonly IDynamicRepository repository;
        private readonly DataSourceChooser dataSourceChooser;

        public SportServiceImp(IDynamicRepository repository, DataSourceChooser dataSourceChooser)
        {
            this.repository = repository;
            this.dataSourceChooser = dataSourceChooser;
        }

        public async Task<SummaryEntity<SportItemModel>> Query(SportHttpParameter parammeter)
        {
            var criteria = Mapper.Map<SportCriteria>(parammeter);
            criteria.Source = dataSourceChooser.GetSource(parammeter.TimeRange);
            var summaryEntities = (await repository.FetchAsync<SportEntity>(criteria)).CalculateSummaryEntity();

            var result = BindingItems(parammeter.IsShowFullColumn, summaryEntities);
            return result;
        }

        private SummaryEntity<SportItemModel> BindingItems(bool isShowFullColumn, SummaryEntity<SportEntity> entities)
        {
            var result = new SummaryEntity<SportItemModel>();
            foreach (var entity in entities.Entities)
            {
                var item = BindingItem(isShowFullColumn, entity);
                result.Entities.Add(item);
            }

            var totalItem = BindingItem(isShowFullColumn, entities.Total);
            result.Total = totalItem;

            return result;
        }

        private SportItemModel BindingItem(bool isShowFullColumn, SportEntity entity)
        {
            var income = isShowFullColumn ? entity.RealIncome : 0;
            var turnover = isShowFullColumn ? entity.RealTurnover : 0;

            return new SportItemModel
            {
                Id = entity.Id,
                Sport = entity.Sport,
                ActiveMembers = entity.ActiveMembers,
                BetCount = entity.BetCount,
                RealIncome = income,
                RealTurnover = turnover,
                RealMargin = entity.RealMargin
            };
        }
    }
}