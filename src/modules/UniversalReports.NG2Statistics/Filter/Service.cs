using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace UniversalReports.NG2Statistics.Filter
{
    public interface Service
    {
        List<Sport> QuerySports(SportCriteria criteria);

        List<UserNameModel> QueryUserNames(UserSearchCriteria criteria);

        List<Entity> QueryCurrency(CurrencyCriteria criteria);
    }

    public class ServiceImp : Service
    {
        private readonly IDynamicRepository repository;

        public ServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public List<Entity> QueryCurrency(CurrencyCriteria criteria)
        {
            var currencies = repository.Fetch<Entity>(criteria)
                .OrderBy(c => c.Name)
                .ToList();
            currencies.Insert(0, new Entity { Id = 0, Name = "All" });
            currencies.Insert(1, new Entity { Id = -1, Name = "Base RM" });

            return currencies;
        }

        public List<Sport> QuerySports(SportCriteria criteria)
        {
            var rawSports = repository.Fetch<SportRaw>(criteria).ToList();
            var sportList = new List<Sport>();
            rawSports
                .Select(group => new { group.SportId, group.SportName })
                .Distinct()
                .ToList()
                .ForEach(sport =>
                {
                    var sportType = new Sport { Checked = true, Id = sport.SportId, Name = sport.SportName };
                    rawSports
                        .Where(s => s.SportId == sport.SportId)
                        .ToList()
                        .ForEach(bettype => sportType.Children.Add(new Sport { Checked = true, Id = bettype.BettypeId, Name = bettype.BettypeName }));

                    sportList.Add(sportType);
                });

            return sportList;
        }

        public List<UserNameModel> QueryUserNames(UserSearchCriteria criteria)
        {
            return repository.Fetch<UserNameModel>(criteria).ToList();
        }
    }
}