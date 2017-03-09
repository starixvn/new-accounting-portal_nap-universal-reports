using System.Collections.Generic;

namespace UniversalReports.PunterAnalysis.Core
{
    public class ReportModelBase<T> where T : class, new()
    {
        public List<T> Entities { get; set; } = new List<T> { };

        public T Total { get; set; } = new T();
    }
}
