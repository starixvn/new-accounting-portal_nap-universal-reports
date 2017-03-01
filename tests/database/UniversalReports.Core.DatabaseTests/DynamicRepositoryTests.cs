using Fanex.Data.Repository;
using NUnit.Framework;
using UniversalReports.Core.BalanceUpServices;

namespace UniversalReports.Core.DatabaseTests
{
    public class DynamicRepositoryTests
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