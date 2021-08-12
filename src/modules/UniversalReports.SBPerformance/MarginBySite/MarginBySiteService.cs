using AutoMapper;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using System.Threading.Tasks;
using UniversalReports.SBPerformance.Common;

namespace UniversalReports.SBPerformance.MarginBySite
{
    public interface MarginBySiteService
    {
        Task<SummaryEntity<MarginBySiteItemModel>> Query(MarginBySiteHttpParameter parammeter);
    }

    public class MarginBySiteServiceImp : MarginBySiteService
    {
        private readonly IDynamicRepository repository;
        private readonly DataSourceChooser dataSourceChooser;

        public MarginBySiteServiceImp(IDynamicRepository repository, DataSourceChooser dataSourceChooser)
        {
            this.repository = repository;
            this.dataSourceChooser = dataSourceChooser;
        }

        public async Task<SummaryEntity<MarginBySiteItemModel>> Query(MarginBySiteHttpParameter parammeter)
        {
            var criteria = Mapper.Map<MarginBySiteCriteria>(parammeter);
            criteria.Source = dataSourceChooser.GetSource(parammeter.TimeRange);
            var summaryEntities = (await repository.FetchAsync<MarginBySiteEntity>(criteria)).CalculateSummaryEntity();

            var result = BindingItems(parammeter.IsShowFullColumn, summaryEntities);
            return result;
        }

        private SummaryEntity<MarginBySiteItemModel> BindingItems(bool isShowFullColumn, SummaryEntity<MarginBySiteEntity> entities)
        {
            var result = new SummaryEntity<MarginBySiteItemModel>();
            foreach (var entity in entities.Entities)
            {
                var item = BindingItem(isShowFullColumn, entity);
                result.Entities.Add(item);
            }

            var totalItem = BindingItem(isShowFullColumn, entities.Total);
            result.Total = totalItem;

            return result;
        }

        private MarginBySiteItemModel BindingItem(bool isShowFullColumn, MarginBySiteEntity entity)
        {
            var income = isShowFullColumn ? entity.RealIncome : 0;
            var turnover = isShowFullColumn ? entity.RealTurnover : 0;

            return new MarginBySiteItemModel
            {
                Id = entity.Id,
                Sport = entity.Sport,
                League = entity.League,
                Event = entity.Event,
                Match = entity.Match,
                BetType = entity.BetType,
                NoBetTypes = entity.NoBetTypes,
                NoMatches = entity.NoMatches,
                ActiveMembers = entity.ActiveMembers,
                BetCount = entity.BetCount,
                RealIncome = income,
                RealTurnover = turnover,
                RealMargin = entity.RealMargin
            };
        }
    }
}