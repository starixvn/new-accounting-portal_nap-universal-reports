using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.MatchDetail;

namespace UniversalReports.HouseWinLoss.UnitTests.Common.MatchDetail
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class GetTeamNameAndSuffixServiceTests
    {
        static object[] TestCaseSourceData =
        {
            new object[] {"Any Name", "3261(O )", "Any Name (O/U)" },
            new object[] {"Any Name", "3261(o)" , "Any Name (O/U)"},
            new object[] {"Any Name", "3261( o)" , "Any Name (O/U)"},
            new object[] {"Any Name", "3261( O)" , "Any Name (O/U)"},
            new object[] {"Any Name", "3261(h)" , "Any Name (HDP)"},
            new object[] {"Any Name", "3261(H)" , "Any Name (HDP)"},
            new object[] {"Any Name", "3261(h )" , "Any Name (HDP)"},
            new object[] {"Any Name", "3261( H)", "Any Name (HDP)" }
        };

        [Test, TestCaseSource("TestCaseSourceData")]
        public void GetTeamNameWithSuffixByMatchCode_WithTeamAndMatchCode_ReturnRightTeamAndSuffix(string teamName, string matchCode, string teamNameWithSuffix)
        {
            // Arrange
            var service = new GetTeamNameAndSuffixServiceImp();

            // Act
            var result = service.GetTeamNameWithSuffixByMatchCode(teamName, matchCode);

            // Assert
            Assert.That(result, Is.EqualTo(teamNameWithSuffix));
        }
    }
}
