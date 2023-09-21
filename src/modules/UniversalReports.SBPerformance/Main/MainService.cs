using AutoMapper;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using System.Threading.Tasks;
using UniversalReports.SBPerformance.Common;

namespace UniversalReports.SBPerformance.Main
{
    public interface MainService
    {
        Task<SummaryEntity<ItemModel>> Query(HttpParameter parammeter);
    }

    public class MainServiceImp : MainService
    {
        private readonly IDynamicRepository repository;

        private readonly DataSourceChooser dataSourceChooser;

        public MainServiceImp(IDynamicRepository repository, DataSourceChooser dataSourceChooser)
        {
            this.repository = repository;
            this.dataSourceChooser = dataSourceChooser;
        }

        public async Task<SummaryEntity<ItemModel>> Query(HttpParameter parammeter)
        {
            var criteria = Mapper.Map<Criteria>(parammeter);
            criteria.Source = dataSourceChooser.GetSource(parammeter.TimeRange);
            var summaryEntities = (await repository.FetchAsync<Entity>(criteria)).CalculateSummaryEntity();

            var result = BindingItems(parammeter.IsShowFullColumn, summaryEntities);
            return result;
        }

        private SummaryEntity<ItemModel> BindingItems(bool isShowFullColumn, SummaryEntity<Entity> entities)
        {
            var result = new SummaryEntity<ItemModel>();
            foreach (var entity in entities.Entities)
            {
                var item = BindingItem(isShowFullColumn, entity);
                result.Entities.Add(item);
            }

            var totalItem = BindingItem(isShowFullColumn, entities.Total);
            result.Total = totalItem;

            return result;
        }

        private ItemModel BindingItem(bool isShowFullColumn, Entity entity)
        {
            var income = isShowFullColumn ? entity.RealIncome : 0;
            var turnover = isShowFullColumn ? entity.RealTurnover : 0;

            return new ItemModel
            {
                Id = entity.Id,
                Name = entity.Name,
                BetCount = entity.BetCount,
                RealIncome = income,
                RealTurnover = turnover,
                RealMargin = entity.RealMargin
            };
        }
    }
}