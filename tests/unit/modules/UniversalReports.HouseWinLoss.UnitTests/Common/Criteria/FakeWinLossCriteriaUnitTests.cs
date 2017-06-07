using NUnit.Framework;

namespace UniversalReports.HouseWinLoss.UnitTests.Common.Criteria
{
    public class FakeWinLossCriteriaUnitTests
    {
        [Test]
        public void GetSettingKey_AlwaysReturnsEmpty()
        {
            var criteria = new FakeWinLossCriteria();
            var settingKey = criteria.GetSettingKey();

            Assert.That(settingKey, Is.Empty);
        }
    }
}
