using System.Linq;
using AutoMapper;
using Fanex.Data.Repository;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.GrandTotal
{
    public interface GrandTotalService
    {
        GrandTotalModel Query(QueryModel queryModel);
    }

    public class GrandTotalServiceImp : GrandTotalService
    {
        private readonly BalanceUpService balance;

        private readonly IDynamicRepository repository;

        public GrandTotalServiceImp(BalanceUpService balance, IDynamicRepository repository)
        {
            this.balance = balance;
            this.repository = repository;
        }

        public GrandTotalModel Query(QueryModel queryModel)
        {
            var criteria = Mapper.Map<GrandTotalCriteria>(queryModel);
            criteria.MoveBetsDay = balance.Query().MoveBetsDate;

            var rawData = repository.FetchMultiple<GrandTotalModel, GrandTotalModel>(criteria);

            return new GrandTotalModel
            {
                Rows = rawData.Item1.ToList(),
                Total = rawData.Item2.FirstOrDefault()
            };
        }
    }
}