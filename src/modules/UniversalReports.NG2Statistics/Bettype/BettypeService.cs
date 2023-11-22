using System.Linq;
using AutoMapper;
using Fanex.Data.Repository;
using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.Bettype
{
    using BalanceUpServices;

    public interface BettypeService
    {
        BettypeModel Query(QueryModel queryModel);
    }

    public class BettypeServiceImp : BettypeService
    {
        private readonly BalanceUpService balance;
        private readonly IDynamicRepository repository;

        public BettypeServiceImp(BalanceUpService balance, IDynamicRepository repository)
        {
            this.balance = balance;
            this.repository = repository;
        }

        public BettypeModel Query(QueryModel queryModel)
        {
            var bettypeModel = new BettypeModel { Total = new BettypeModel() };

            var criteria = Mapper.Map<BettypeCriteria>(queryModel);
            criteria.MoveBetsDay = balance.Query().MoveBetsDate;

            var rawData = repository.FetchMultiple<BettypeModel, BettypeModel>(criteria);

            var sportIds = rawData.Item1.Select(s => new { s.SportId, s.Sporttype }).Distinct().ToList();
            foreach (var sportId in sportIds)
            {
                var bettypeIds = rawData.Item1.Where(s => s.SportId == sportId.SportId)
                    .Select(b => new { b.BettypeId, b.Bettype }).Distinct().ToList();

                var sportTypeRow = new BettypeModel { SportId = sportId.SportId, Sporttype = sportId.Sporttype };
                foreach (var bettypeId in bettypeIds)
                {
                    var rows = rawData.Item1.Where(s => s.SportId == sportId.SportId && s.BettypeId == bettypeId.BettypeId).ToList();
                    sportTypeRow.Rows.Add(new BettypeModel { Rows = rows, BettypeId = bettypeId.BettypeId, Bettype = bettypeId.Bettype });
                }

                bettypeModel.Rows.Add(sportTypeRow);
            }

            bettypeModel.Total = rawData.Item2.FirstOrDefault();
            bettypeModel.Total.Bettype = "Grand Total RM";

            return bettypeModel;
        }
    }
}