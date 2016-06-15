using Fanex.Data.Repository;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetail
{
    public class RawWinLossServiceImp : RawWinLossService
    {
        private readonly IDynamicRepository repository;

        private readonly BalanceUpSourceChooser balanceUpSourceChooser;

        public RawWinLossServiceImp(
            IDynamicRepository repository,
            BalanceUpSourceChooser balanceUpSourceChooser)
        {
            this.repository = repository;
            this.balanceUpSourceChooser = balanceUpSourceChooser;
        }

        public virtual List<RawWinLoss> Query(WinLossCriteria criteria)
        {
            criteria.Source = balanceUpSourceChooser.Determine(criteria);
            var result = repository.Fetch<RawWinLoss>(criteria).ToList();
            var fileName = criteria.GetType().FullName + "-" + criteria.Source;
            var criteriaFileName = "D:\\" + fileName + "-criteria.json";
            var fakeDataFileName = "D:\\" + fileName + "-fakeData.json";
            var json = JsonConvert.SerializeObject(criteria, Formatting.Indented);
            System.IO.File.WriteAllText(criteriaFileName, json);
            json = JsonConvert.SerializeObject(result, Formatting.Indented);
            System.IO.File.WriteAllText(fakeDataFileName, json);

            return result;
        }
    }
}