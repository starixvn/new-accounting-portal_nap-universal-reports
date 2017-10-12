namespace UniversalReports.PlayForFun.Summary.Model
{
    public class ExcelSetting
    {
        public string TemplatePath { get; set; }

        public string SheetName { get; set; }

        public int StartRowIndex { get; set; }

        public string Title { get; set; }

        public string TitleCellRange { get; set; }

        public int MergedColumnCountOfTotalRow { get; set; }
    }
}