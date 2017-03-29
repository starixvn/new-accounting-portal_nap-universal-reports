namespace UniversalReports.PunterAnalysis.Core
{
    public class ExcelSettings
    {
        public string TemplatePath { get; set; }

        public string SheetName { get; set; }

        public int StartRowIndex { get; set; }

        public string Title { get; set; }

        public string TitleCellRange { get; set; }

        public string Description { get; set; }

        public string DescriptionCellRange { get; set; }
    }
}
