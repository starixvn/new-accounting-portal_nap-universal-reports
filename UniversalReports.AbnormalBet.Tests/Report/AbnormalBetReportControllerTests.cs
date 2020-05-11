using NUnit.Framework;
using Olympus.WebApi.Epplus;
using SimpleInjector;
using System;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.HttpParameter;
using UniversalReports.AbnormalBet.Model;
using UniversalReports.AbnormalBet.Report;
using UniversalReports.AbnormalBet.Tests.DependencyInjection;

namespace UniversalReports.AbnormalBet.Tests.Report
{
    public class AbnormalBetReportControllerTests
    {
        private const string FakeRepositoryDataFileName = "Member-AbnormalBet-FileRepository.json";
        private const string FakeRepositoryLocationDataFileName = "Localtion-AbnormalBet-FileRepository.json";

        private const string FakeLicenseeRepositoryDataFileName = "Licensee-AbnormalBet-FileRepository.json";

        [Test]
        public async Task MemberExcel_FileRepository_ReturnsRightExcelPackage()
        {
            // Arrange
            var expectedTitle = TestDataLoader.Load<object[,]>("Member-AbnormalBet-Excel-ExpectedTitle.json");
            var expectedBody = TestDataLoader.Load<object[,]>("Member-AbnormalBet-Excel-ExpectedBody.json");


            var container = new Container();
            var factory = new ApiControllerFactoryMethodFetchAsync(container);
            var controller = factory.CreateController<AbnormalBetReportController, MemberModel, LocationModel>(
                FakeRepositoryDataFileName,
                FakeRepositoryLocationDataFileName);

            // Act
            var httpActionResult = await controller.MemberExcel(new MemberHttpParameterExcel
            {
                FromDate = new DateTime(2018, 9, 1),
                ToDate = new DateTime(2018, 9, 20),
                Reason = "1, 2",
                Sport = "1,2",
                BetType = "1, 2",
                Licensee = "1, 2",
                Member = "1, 2",
                IsTest = true,
                Title = "Title"
            });

            var excelPackage = (httpActionResult as EpplusExcelResult).ExcelPackage;
            var voidBetWorkSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(voidBetWorkSheet.Name, Is.EqualTo("Abnormal Bet Void"));

            Assert.That(voidBetWorkSheet.Cells["A1:M2"].Value, Is.EqualTo(expectedTitle));
            Assert.That(voidBetWorkSheet.Cells["A5:M6"].Value, Is.EqualTo(expectedBody));

            // Release
            container.Dispose();
        }

        [Test]
        public async Task LicenseeExcel_FileRepository_ReturnsRightExcelPackage()
        {
            // Arrange
            var expectedTitle = TestDataLoader.Load<object[,]>("Licensee-AbnormalBet-Excel-ExpectedTitle.json");
            var expectedBody = TestDataLoader.Load<object[,]>("Licensee-AbnormalBet-Excel-ExpectedBody.json");


            var container = new Container();
            var factory = new ApiControllerFactoryMethodFetchAsync(container);
            var controller = factory.CreateController<AbnormalBetReportController, LicenseeModel, LocationModel>(
                FakeLicenseeRepositoryDataFileName,
                FakeRepositoryLocationDataFileName);

            // Act
            var httpActionResult = await controller.LicenseeExcel(new LicenseeHttpParameterExcel
            {
                FromDate = new DateTime(2018, 9, 1),
                ToDate = new DateTime(2018, 9, 20),
                Reason = "1, 2",
                Sport = "1,2",
                BetType = "1, 2",
                Licensee = "1, 2",
                IsTest = true,
                Title = "Title"
            });

            var excelPackage = (httpActionResult as EpplusExcelResult).ExcelPackage;
            var voidBetWorkSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(voidBetWorkSheet.Name, Is.EqualTo("Abnormal Bet Void"));
            Assert.That(voidBetWorkSheet.Cells["A1:O2"].Value, Is.EqualTo(expectedTitle));
            Assert.That(voidBetWorkSheet.Cells["A5:O6"].Value, Is.EqualTo(expectedBody));

            // Release
            container.Dispose();
        }
    }
}
