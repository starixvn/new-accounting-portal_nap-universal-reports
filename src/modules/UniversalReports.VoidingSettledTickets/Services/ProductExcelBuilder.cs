using Epplus.Mapper.Extensions;
using Linq.DynamicSum;
using OfficeOpenXml;
using System.IO;
using UniversalReports.VoidingSettledTickets.Models;

namespace UniversalReports.VoidingSettledTickets.Services
{
    using Configurations;

    public interface ProductExcelBuilder
    {
        ExcelPackage Build(SummaryEntity<ProductExcelModel> productsExcel);
    }

    public class ProductExcelBuilderImp : ProductExcelBuilder
    {
        private readonly ConfigurationService configurationService;

        private ExcelWorksheet productActual;

        private ExcelWorksheet totalSheet;

        private const int StartRowIndex = 4;

        private ExcelPackage ExcelPackage { get; set; }

        public ProductExcelBuilderImp(ConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public ExcelPackage Build(SummaryEntity<ProductExcelModel> productsExcel)
        {
            LoadTemplate();
            productActual.ApplyVertical(productsExcel.Entities, StartRowIndex);
            productsExcel.Total.ProductGroup = "Total";
            productActual.ApplyModel(totalSheet, productsExcel.Total, StartRowIndex + productsExcel.Entities.Count);
            ClearTemplate();
            return ExcelPackage;
        }

        private void LoadTemplate()
        {
            var templateAbsolutelyPath = $"{configurationService.CurrentDirectory}\\ExcelTemplate\\VoidingSettledTicket\\Product.xlsx";
            using (var stream = new FileStream(templateAbsolutelyPath, FileMode.Open, FileAccess.Read))
            {
                ExcelPackage = new ExcelPackage(stream);
                productActual = ExcelPackage.Workbook.Worksheets.Copy("ItemTemplate", "Overall Win Loss");
                totalSheet = ExcelPackage.Workbook.Worksheets["TotalTemplate"];
            }
        }

        private void ClearTemplate()
        {
            ExcelPackage.Workbook.Worksheets.Delete("ItemTemplate");
            ExcelPackage.Workbook.Worksheets.Delete("TotalTemplate");
        }
    }
}