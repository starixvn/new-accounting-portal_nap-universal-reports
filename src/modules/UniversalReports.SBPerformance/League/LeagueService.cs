using AutoMapper;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using System.Threading.Tasks;
using UniversalReports.SBPerformance.Common;

namespace UniversalReports.SBPerformance.League
{
    public interface LeagueService
    {
        Task<SummaryEntity<LeagueItemModel>> Query(LeagueHttpParameter parammeter);
    }

    public class LeagueServiceImp : LeagueService
    {
        private readonly IDynamicRepository repository;
        private readonly DataSourceChooser dataSourceChooser;

        public LeagueServiceImp(IDynamicRepository repository, DataSourceChooser dataSourceChooser)
        {
            this.repository = repository;
            this.dataSourceChooser = dataSourceChooser;
        }

        public async Task<SummaryEntity<LeagueItemModel>> Query(LeagueHttpParameter parammeter)
        {
            var criteria = Mapper.Map<LeagueCriteria>(parammeter);
            criteria.Source = dataSourceChooser.GetSource(parammeter.TimeRange);
            var summaryEntities = (await repository.FetchAsync<LeagueEntity>(criteria)).CalculateSummaryEntity();

            var result = BindingItems(parammeter.IsShowFullColumn, summaryEntities);
            return result;
        }

        private SummaryEntity<LeagueItemModel> BindingItems(bool isShowFullColumn, SummaryEntity<LeagueEntity> entities)
        {
            var result = new SummaryEntity<LeagueItemModel>();
            foreach (var entity in entities.Entities)
            {
                var item = BindingItem(isShowFullColumn, entity);
                result.Entities.Add(item);
            }

            var totalItem = BindingItem(isShowFullColumn, entities.Total);
            result.Total = totalItem;

            return result;
        }

        private LeagueItemModel BindingItem(bool isShowFullColumn, LeagueEntity entity)
        {
            var income = isShowFullColumn ? entity.RealIncome : 0;
            var turnover = isShowFullColumn ? entity.RealTurnover : 0;

            return new LeagueItemModel
            {
                Id = entity.Id,
                League = entity.League,
                ActiveMembers = entity.ActiveMembers,
                BetCount = entity.BetCount,
                RealIncome = income,
                RealTurnover = turnover,
                RealMargin = entity.RealMargin
            };
        }
    }
}