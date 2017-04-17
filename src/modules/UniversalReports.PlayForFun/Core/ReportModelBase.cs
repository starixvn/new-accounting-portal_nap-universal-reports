using System.Collections.Generic;

namespace UniversalReports.PlayForFun.Core
{
    public class ReportModelBase<T> where T : class, new()
    {
        public List<T> Entities { get; set; } = new List<T>();

        public T Total { get; set; } = new T();
    }
}