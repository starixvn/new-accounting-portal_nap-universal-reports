using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Common.Services
{
    public interface RawWinLossService
    {
        List<WinLossRaw> Query(WinLossCriteria criteria);
    }

    public class RawWinLossServiceImp : RawWinLossService
    {
        private readonly IDynamicRepository repository;


        public RawWinLossServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public virtual List<WinLossRaw> Query(WinLossCriteria criteria)
        {
            return repository.Fetch<WinLossRaw>(criteria).ToList();
        }
    }
}