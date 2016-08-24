using Fanex.Data.Repository;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;

namespace UniversalReports.CompanyWinLoss.DatabaseTests.Repository
{
    public class BalanceUpRepositoryTests
    {
        [Test]
        [Category("RepositoryTests")]
        public void Get_Successful()
        {
            var repository = new DynamicRepository();
            var criteria = new BalanceUpCriteria();
            repository.Get<BalanceUpRange>(criteria);
        }
    }
}
