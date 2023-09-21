using AutoMapper;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using System.Threading.Tasks;
using UniversalReports.SBPerformance.Common;

namespace UniversalReports.SBPerformance.TopLosingLeague
{
    public interface TopLosingLeagueService
    {
        Task<SummaryEntity<TopLosingLeagueItemModel>> Query(TopLosingLeagueHttpParameter parammeter);
    }

    public class TopLosingLeagueServiceImp : TopLosingLeagueService
    {
        private readonly IDynamicRepository repository;
        private readonly DataSourceChooser dataSourceChooser;

        public TopLosingLeagueServiceImp(IDynamicRepository repository, DataSourceChooser dataSourceChooser)
        {
            this.repository = repository;
            this.dataSourceChooser = dataSourceChooser;
        }

        public async Task<SummaryEntity<TopLosingLeagueItemModel>> Query(TopLosingLeagueHttpParameter parammeter)
        {
            var criteria = Mapper.Map<TopLosingLeagueCriteria>(parammeter);
            var summaryEntities = (await repository.FetchAsync<TopLosingLeagueEntity>(criteria)).CalculateSummaryEntity();

            var result = BindingItems(parammeter.IsShowFullColumn, summaryEntities);
            return result;
        }

        private SummaryEntity<TopLosingLeagueItemModel> BindingItems(bool isShowFullColumn, SummaryEntity<TopLosingLeagueEntity> entities)
        {
            var result = new SummaryEntity<TopLosingLeagueItemModel>();
            foreach (var entity in entities.Entities)
            {
                var item = BindingItem(isShowFullColumn, entity);
                result.Entities.Add(item);
            }

            var totalItem = BindingItem(isShowFullColumn, entities.Total);
            result.Total = totalItem;

            return result;
        }

        private TopLosingLeagueItemModel BindingItem(bool isShowFullColumn, TopLosingLeagueEntity entity)
        {
            var income = isShowFullColumn ? entity.RealIncome : 0;
            var turnover = isShowFullColumn ? entity.RealTurnover : 0;

            return new TopLosingLeagueItemModel
            {
                Id = entity.Id,
                Site = entity.Site,
                League = entity.League,
                Event = entity.Event,
                Match = entity.Match,
                BetType = entity.BetType,
                Username = entity.Username,
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