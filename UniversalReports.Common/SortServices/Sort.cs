using System;
using System.Collections.Generic;
using System.Reflection;
using Fanex.Common;

namespace UniversalReports.Common.SortServices
{
    public static class Sort
    {
        public static void SortDataByProperty<T>(List<T> dataSource, string sortDirection, string sortColumnName)
        {
            PropertyInfo propInfo = typeof(T).GetProperty(sortColumnName);

            Comparison<T> compare = delegate (T a, T b)
            {
                bool isAsc = string.Equals(sortDirection, SortDirectionConstants.Asc, StringComparison.OrdinalIgnoreCase);
                var valueA = isAsc ? propInfo.GetValue(a, null) : propInfo.GetValue(b, null);
                var valueB = isAsc ? propInfo.GetValue(b, null) : propInfo.GetValue(a, null);

                return valueA is IComparable ? ((IComparable)valueA).CompareTo(valueB) : 0;
            };

            dataSource.Sort(compare);
        }
    }
}