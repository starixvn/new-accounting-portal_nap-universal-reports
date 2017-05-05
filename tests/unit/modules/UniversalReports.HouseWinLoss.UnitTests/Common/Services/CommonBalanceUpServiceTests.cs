using Fanex.Caching;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using System;
using UniversalReports.Core.BalanceUpServices;

namespace UniversalReports.HouseWinLoss.UnitTests.Common.Services
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class CommonBalanceUpServiceTests
    {
        private const string BalanceUpRangeCacheKey = "CommonBalanceUpRangeCacheKey";

        [Test]
        public void Query_Always_CallCacheService()
        {
            // Arrange
            var dynamicRepository = Substitute.For<IDynamicRepository>();
            var cacheService = Substitute.For<CacheService>();

            var balanceUpService = new BalanceUpServiceImp(dynamicRepository, cacheService);

            // Act
            balanceUpService.Query();

            // Assert
            cacheService.Received().GetOrSet(BalanceUpRangeCacheKey, Arg.Any<Func<BalanceUpRange>>());
        }

        [Test]
        public void QueryFromSource_Always_CallDynamicRepository()
        {
            // Arrange
            var dynamicRepository = Substitute.For<IDynamicRepository>();
            var cacheService = Substitute.For<CacheService>();
            var balanceUpService = new BalanceUpServiceImp(dynamicRepository, cacheService);

            // Act
            balanceUpService.QueryFromSource();

            // Assert
            dynamicRepository.Received().Get<BalanceUpRange>(Arg.Any<BalanceUpCriteria>());
        }
    }
}