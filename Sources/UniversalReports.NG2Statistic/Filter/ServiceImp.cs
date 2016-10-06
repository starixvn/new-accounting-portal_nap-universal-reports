using System.Collections.Generic;
using System.Linq;
using Fanex.Repository;

namespace UniversalReports.NG2Statistic.Filter
{
    public class ServiceImp : Service
    {
        private readonly SimpleRepository repository;

        public ServiceImp(SimpleRepository repository)
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
                .Select(sport => new { sport.SportId, sport.SportName })
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

        public List<dynamic> QueryUserNames(UserSearchCriteria criteria)
        {
            return repository.Fetch<dynamic>(criteria).ToList();
        }
    }
}