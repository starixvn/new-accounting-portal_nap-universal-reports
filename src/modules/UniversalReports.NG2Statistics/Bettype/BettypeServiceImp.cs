using AutoMapper;
using System.Linq;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.Bettype
{
    public interface BettypeService
    {
        BettypeModel Query(QueryModel queryModel);
    }

    public class BettypeServiceImp : BettypeService
    {
        private readonly BalanceUpService balance;
        private readonly Repository repository;

        public BettypeServiceImp(BalanceUpService balance, Repository repository)
        {
            this.balance = balance;
            this.repository = repository;
        }

        public BettypeModel Query(QueryModel queryModel)
        {
            var bettypeModel = new BettypeModel { Total = new BettypeModel() };

            var criteria = Mapper.Map<BettypeCriteria>(queryModel);
            criteria.MoveBetsDay = balance.Query().MoveBetsDate;

            var rawData = repository.QueryRawData(criteria);
            rawData.Total.Bettype = "Grand Total RM";

            var sportIds = rawData.Rows.Select(s => new { s.SportId, s.Sporttype }).Distinct().ToList();
            foreach (var sportId in sportIds)
            {
                var bettypeIds = rawData.Rows.Where(s => s.SportId == sportId.SportId)
                    .Select(b => new { b.BettypeId, b.Bettype }).Distinct().ToList();

                var sportTypeRow = new BettypeModel { SportId = sportId.SportId, Sporttype = sportId.Sporttype };
                foreach (var bettypeId in bettypeIds)
                {
                    var rows = rawData.Rows.Where(s => s.SportId == sportId.SportId && s.BettypeId == bettypeId.BettypeId).ToList();
                    sportTypeRow.Rows.Add(new BettypeModel { Rows = rows, BettypeId = bettypeId.BettypeId, Bettype = bettypeId.Bettype });
                }

                bettypeModel.Rows.Add(sportTypeRow);
            }

            bettypeModel.Total = rawData.Total;

            return bettypeModel;
        }
    }
}