using NUnit.Framework;
using OfficeOpenXml;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.WebAPI.Results;

namespace UniversalReports.WebAPI.UnitTests.Results
{
    public class ExcelResultUnitTests
    {
        [Test]
        public async Task ExecuteAsync_NoPassword_AlwaysReturnsExcelMedia()
        {
            // Arrange
            var excelPackage = new ExcelPackage();
            excelPackage.Workbook.Worksheets.Add("Content");

            var excelResult = new ExcelResult(excelPackage, string.Empty);

            // Act
            var result = await excelResult.ExecuteAsync(new CancellationToken());

            // Assert
            Assert.That(result.Content.Headers.ContentType.MediaType, Is.EqualTo("application/vnd.ms-excel"));
        }

        [Test]
        public async Task ExecuteAsync_Password_AlwaysReturnsExcelMedia()
        {
            // Arrange
            var excelPackage = new ExcelPackage();
            excelPackage.Workbook.Worksheets.Add("Content");

            var excelResult = new ExcelResult(excelPackage, "Any Password");

            // Act
            var result = await excelResult.ExecuteAsync(new CancellationToken());

            // Assert
            Assert.That(result.Content.Headers.ContentType.MediaType, Is.EqualTo("application/vnd.ms-excel"));
        }
    }
}
