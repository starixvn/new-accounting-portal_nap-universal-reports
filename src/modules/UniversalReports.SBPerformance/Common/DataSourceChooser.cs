namespace UniversalReports.SBPerformance.Common
{
    public interface DataSourceChooser
    {
        string GetSource(int timeRange);
    }

    public class DataSourceChooserImp : DataSourceChooser
    {
        public string GetSource(int timeRange)
        {
            return timeRange == -1 ? "bettrans" : "Warehouse";
        }
    }
}