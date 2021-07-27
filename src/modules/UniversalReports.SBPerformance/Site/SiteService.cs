using AutoMapper;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using System.Threading.Tasks;
using UniversalReports.SBPerformance.Common;

namespace UniversalReports.SBPerformance.Site
{
    public interface SiteService
    {
        Task<SummaryEntity<SiteItemModel>> Query(SiteHttpParameter parammeter);
    }

    public class SiteServiceImp : SiteService
    {
        private readonly IDynamicRepository repository;
        private readonly DataSourceChooser dataSourceChooser;

        public SiteServiceImp(IDynamicRepository repository, DataSourceChooser dataSourceChooser)
        {
            this.repository = repository;
            this.dataSourceChooser = dataSourceChooser;
        }

        public async Task<SummaryEntity<SiteItemModel>> Query(SiteHttpParameter parammeter)
        {
            var criteria = Mapper.Map<SiteCriteria>(parammeter);
            criteria.Source = dataSourceChooser.GetSource(parammeter.TimeRange);
            var summaryEntities = (await repository.FetchAsync<SiteEntity>(criteria)).CalculateSummaryEntity();

            var result = BindingItems(parammeter.IsShowFullColumn, summaryEntities);
            return result;
        }

        private SummaryEntity<SiteItemModel> BindingItems(bool isShowFullColumn, SummaryEntity<SiteEntity> entities)
        {
            var result = new SummaryEntity<SiteItemModel>();
            foreach (var entity in entities.Entities)
            {
                var item = BindingItem(isShowFullColumn, entity);
                result.Entities.Add(item);
            }

            var totalItem = BindingItem(isShowFullColumn, entities.Total);
            result.Total = totalItem;

            return result;
        }

        private SiteItemModel BindingItem(bool isShowFullColumn, SiteEntity entity)
        {
            var income = isShowFullColumn ? entity.RealIncome : 0;
            var turnover = isShowFullColumn ? entity.RealTurnover : 0;

            return new SiteItemModel
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