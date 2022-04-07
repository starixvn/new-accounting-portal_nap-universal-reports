using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Common.MatchDetail
{
    public interface RawWinLossService
    {
        List<RawWinLoss> Query(WinLossCriteria criteria);
    }

    public class RawWinLossServiceImp : RawWinLossService
    {
        private readonly IDynamicRepository repository;

        public RawWinLossServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public virtual List<RawWinLoss> Query(WinLossCriteria criteria)
        {
            return repository.Fetch<RawWinLoss>(criteria).ToList();
        }
    }
}