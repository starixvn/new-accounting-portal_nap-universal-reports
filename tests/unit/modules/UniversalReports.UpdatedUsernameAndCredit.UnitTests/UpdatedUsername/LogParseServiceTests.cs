using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.UpdatedUsernameAndCredit.UpdatedUsername;

namespace UniversalReports.UpdatedUsernameAndCredit.UnitTests.UpdatedUsername
{
    [TestFixture]
    public class LogParseServiceTests
    {
        [Test]
        public void GetUsernameLog_WithTrackingValue_ReturnRightUsernameLogModel()
        {
            // Arrange
            var expectedUsernameLogModel = new UsernameLogModel
            {
                FromName = "PHL-Data Center & Bandwidth",
                ToName = "PHL-Data Center & Bandwidth19"
            };

            string tracking = "<Acc_CustomerUpdUserName  FromName=\"PHL-Data Center & Bandwidth\" ToName=\"PHL-Data Center & Bandwidth19\" userid=\"15477075\" IP=\"\" ErrCode=\"0\" ErrMsg=\"\" />";
            var service = new LogParseServiceImp();

            // Act
            var model = service.GetUsernameLog(tracking);

            // Assert
            Assert.That(model, IsDeeplyEqual.To(expectedUsernameLogModel));
        }

        [Test]
        public void GetUsernameLog_WithInValidTrackingValue_ReturnRightUsernameLogModel()
        {
            // Arrange
            var expectedUsernameLogModel = new UsernameLogModel
            {
                FromName = string.Empty,
                ToName = "PHL-Data Center & Bandwidth19 />"
            };

            string tracking = "<Acc_CustomerUpdUserName ToName=\"PHL-Data Center & Bandwidth19 />";
            var service = new LogParseServiceImp();

            // Act
            var model = service.GetUsernameLog(tracking);

            // Assert
            Assert.That(model, IsDeeplyEqual.To(expectedUsernameLogModel));
        }
    }
}
