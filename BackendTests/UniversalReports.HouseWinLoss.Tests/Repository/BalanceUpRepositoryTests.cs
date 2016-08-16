using Fanex.Data.Repository;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.BalanceUpServices;

namespace UniversalReports.HouseWinLoss.Tests.Repository
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
