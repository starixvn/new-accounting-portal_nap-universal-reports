using Fanex.Data.Repository;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.Framework;
using Olympus.FPSAPI.Client;
using Olympus.WebApi.Epplus;
using SimpleInjector;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.AssociatedAccount;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;
using UniversalReports.PunterAnalysis.BetCount;
using UniversalReports.PunterAnalysis.League;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.PunterAnalysis.Summary;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection.SimpleInjector;

namespace UniversalReports.PunterAnalysis.Tests.AssociatedAccount
{
    public class PunterAnalysisAssociatedAccountControllerTests
    {
        [Test]
        public async Task Excel_Facade_ReturnsRightExcelPackage()
        {
            // Arrange
            var expectedTitle = TestDataLoader.Load<object[,]>("AssociatedAccount-Excel-ExpectedTitle.json");
            var expectedFilter = TestDataLoader.Load<object[,]>("AssociatedAccount-Excel-ExpectedFilter.json");
            var expectedBody = TestDataLoader.Load<object[,]>("AssociatedAccount-Excel-ExpectedBody.json");
            var expectedTotal = TestDataLoader.Load<object[,]>("AssociatedAccount-Excel-ExpectedTotal.json");

            var container = new Container();
            var controller = CreateController(container);

            // Act
            var httpActionResult = await controller.Excel(new HttpParameterExcel { Title = "Any Title", Filter = "Any Filter" });
            var excelPackage = (httpActionResult as EpplusExcelResult).ExcelPackage;
            var workSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(workSheet.Name, Is.EqualTo("Punter Analysis"));

            Assert.AreEqual(workSheet.Cells["A1:F2"].Value, expectedTitle);
            Assert.AreEqual(workSheet.Cells["A3:F5"].Value, expectedFilter);
            Assert.AreEqual(workSheet.Cells["A8:F10"].Value, expectedBody);
            Assert.AreEqual(workSheet.Cells["A11:F11"].Value, expectedTotal);

            // Release
            container.Dispose();
        }

        private PunterAnalysisAssociatedAccountController CreateController(Container container)
        {
            RegisterFacade(container);
            container.Register<IDynamicRepository, DynamicRepository>();
            container.Register<PunterAnalysisService, PunterAnalysisServiceImp>();
            container.Register<DateTimeService, DateTimeServiceImp>();
            container.Register<LeagueServiceFactory, LeagueServiceFactoryImp>();
            container.Register<FraudServiceWrapper, FraudServiceWrapperImp>();
            container.Register<PunterAnalysisExcelBuilder, PunterAnalysisExcelBuilderImp>();
            container.Register<ExcelSettingFactory, AssociatedAccountExcelSettingFactory>();
            container.Register<LeagueExcelBuilder, LeagueExcelBuilderImp>();
            container.Register<BetCountService, BetCountServiceImp>();
            container.Register<SummaryService, SummaryServiceImp>();

            container.RegiserGlobalServices()
                    .RegisterMediator();
            container.Verify();

            return (PunterAnalysisAssociatedAccountController)container.GetInstance(typeof(PunterAnalysisAssociatedAccountController));
        }

        private void RegisterFacade(Container container)
        {
            var summaryEntity = TestDataLoader.Load<SummaryEntity<AssociatedSummaryModel>>("AssociatedAccount-FileRepository.json");
            var facade = Substitute.For<AssociatedFacade>();
            facade.Query(Arg.Compat.Any<HttpParameterJson>()).Returns(summaryEntity);

            container.Register(() => facade);
        }
    }
}