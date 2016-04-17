using Fanex.Excel.Models;
using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.ColumnBuilders
{
    public class GridOptionColumnRemovalImp : GridOptionColumnRemoval
    {
        public List<Columns> RemoveColumn(List<Columns> columns, int index)
        {
            var actualIndex = GetColumnsActualIndex(columns, index);
            if (ColumnIsInRange(columns, actualIndex))
            {
                RemoveColumnByActualIndex(columns, actualIndex);
            }

            return columns;
        }

        private int GetColumnsActualIndex(List<Columns> columns, int index)
        {
            var currentIndex = 0;
            for (var i = 0; i < columns.Count; i++)
            {
                var column = columns[i];
                currentIndex += column.MergeColNumber == 0 ? 1 : column.MergeColNumber;
                if (currentIndex > index)
                {
                    return i;
                }
            }

            return columns.Count;
        }

        private bool ColumnIsInRange(List<Columns> columns, int actualIndex)
        {
            return actualIndex < columns.Count;
        }

        private void RemoveColumnByActualIndex(List<Columns> columns, int actualIndex)
        {
            var column = columns[actualIndex];

            var needToRemoveColumn = column.MergeColNumber <= 1;

            RemoveOrUpdateColumn(columns, column, needToRemoveColumn);

            var nextColumnIndex = needToRemoveColumn ? actualIndex : actualIndex + 1;
            UpdateColumnIndexAfterRemoveColumn(columns, nextColumnIndex);
        }

        private void RemoveOrUpdateColumn(List<Columns> columns, Columns column, bool remove)
        {
            if (remove)
            {
                columns.Remove(column);
            }
            else
            {
                column.MergeColNumber--;
            }
        }

        private void UpdateColumnIndexAfterRemoveColumn(List<Columns> columns, int index)
        {
            for (var i = index; i < columns.Count; i++)
            {
                columns[i].ColumnIndex--;
            }
        }
    }
}
