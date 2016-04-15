using Fanex.Excel.Models;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.ColumnBuilders;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.ColumnBuilders
{
    [TestFixture]
    [Category("CompanyWinLossColumnBuilderUnitTests")]
    public class ColumnBuilderUnitTests
    {
        [Test]
        public void Remove_RowWithNoMergedColumn_IndexInRange_ColumnIsRemoved()
        {
            // Arrange
            var columns = CreateRowWithNoMergedColumn();
            var builder = new ColumnBuilderImp();

            // Act
            builder.RemoveColumn(columns, 1);

            // Assert
            Assert.AreEqual(2, columns.Count);
            Assert.AreEqual("A", columns[0].Name);
            Assert.AreEqual("C", columns[1].Name);
            Assert.AreEqual(0, columns[0].ColumnIndex);
            Assert.AreEqual(1, columns[1].ColumnIndex);
        }

        [Test]
        public void Remove_RowWithNoMergedColumn_IndexOutOfRange_NothingIsChanged()
        {
            // Arrange
            var columns = CreateRowWithNoMergedColumn();
            var builder = new ColumnBuilderImp();

            // Act
            builder.RemoveColumn(columns, 4);

            // Assert
            Assert.AreEqual(3, columns.Count);
            Assert.AreEqual("A", columns[0].Name);
            Assert.AreEqual("B", columns[1].Name);
            Assert.AreEqual("C", columns[2].Name);
            Assert.AreEqual(0, columns[0].ColumnIndex);
            Assert.AreEqual(1, columns[1].ColumnIndex);
            Assert.AreEqual(2, columns[2].ColumnIndex);
        }

        private List<Columns> CreateRowWithNoMergedColumn()
        {
            return new List<Columns>
            {
                new Columns { ColumnIndex = 0, Name = "A" },
                new Columns { ColumnIndex = 1, Name = "B" },
                new Columns { ColumnIndex = 2, Name = "C" }
            };
        }

        [Test]
        public void Remove_RowWithMergedColumn_IndexAtNoMergedColumn_ColumnIsRemoved()
        {
            // Arrange
            var columns = CreateRowWithMergedColumn();
            var builder = new ColumnBuilderImp();

            // Act
            builder.RemoveColumn(columns, 7);

            // Assert
            Assert.AreEqual(4, columns.Count);
            Assert.AreEqual("A", columns[0].Name);
            Assert.AreEqual("B", columns[1].Name);
            Assert.AreEqual("D", columns[2].Name);
            Assert.AreEqual("E", columns[3].Name);
            Assert.AreEqual(0, columns[0].ColumnIndex);
            Assert.AreEqual(3, columns[1].ColumnIndex);
            Assert.AreEqual(7, columns[2].ColumnIndex);
            Assert.AreEqual(8, columns[3].ColumnIndex);
        }

        [Test]
        public void Remove_RowWithMergedColumn_IndexInFirstMergedRange_MergeColNumberIsChanged()
        {
            // Arrange
            var columns = CreateRowWithMergedColumn();
            var builder = new ColumnBuilderImp();

            // Act
            builder.RemoveColumn(columns, 1);

            // Assert
            Assert.AreEqual(5, columns.Count);
            Assert.AreEqual("A", columns[0].Name);
            Assert.AreEqual("B", columns[1].Name);
            Assert.AreEqual("C", columns[2].Name);
            Assert.AreEqual("D", columns[3].Name);
            Assert.AreEqual("E", columns[4].Name);
            Assert.AreEqual(2, columns[0].MergeColNumber);
            Assert.AreEqual(4, columns[1].MergeColNumber);
            Assert.AreEqual(0, columns[2].MergeColNumber);
            Assert.AreEqual(0, columns[3].MergeColNumber);
            Assert.AreEqual(5, columns[4].MergeColNumber);
            Assert.AreEqual(0, columns[0].ColumnIndex);
            Assert.AreEqual(2, columns[1].ColumnIndex);
            Assert.AreEqual(6, columns[2].ColumnIndex);
            Assert.AreEqual(7, columns[3].ColumnIndex);
            Assert.AreEqual(8, columns[4].ColumnIndex);
        }

        [Test]
        public void Remove_RowWithMergedColumn_IndexInmodelMergedRange_MergeColNumberIsChanged()
        {
            // Arrange
            var columns = CreateRowWithMergedColumn();
            var builder = new ColumnBuilderImp();

            // Act
            builder.RemoveColumn(columns, 5);

            // Assert
            Assert.AreEqual(5, columns.Count);
            Assert.AreEqual("A", columns[0].Name);
            Assert.AreEqual("B", columns[1].Name);
            Assert.AreEqual("C", columns[2].Name);
            Assert.AreEqual("D", columns[3].Name);
            Assert.AreEqual("E", columns[4].Name);
            Assert.AreEqual(3, columns[0].MergeColNumber);
            Assert.AreEqual(3, columns[1].MergeColNumber);
            Assert.AreEqual(0, columns[2].MergeColNumber);
            Assert.AreEqual(0, columns[3].MergeColNumber);
            Assert.AreEqual(5, columns[4].MergeColNumber);
            Assert.AreEqual(0, columns[0].ColumnIndex);
            Assert.AreEqual(3, columns[1].ColumnIndex);
            Assert.AreEqual(6, columns[2].ColumnIndex);
            Assert.AreEqual(7, columns[3].ColumnIndex);
            Assert.AreEqual(8, columns[4].ColumnIndex);
        }

        [Test]
        public void Remove_RowWithMergedColumn_IndexOutOfColumnRange_NothingIsChanged()
        {
            // Arrange
            var columns = CreateRowWithMergedColumn();
            var builder = new ColumnBuilderImp();

            // Act
            builder.RemoveColumn(columns, 16);

            // Assert
            Assert.AreEqual(5, columns.Count);
            Assert.AreEqual("A", columns[0].Name);
            Assert.AreEqual("B", columns[1].Name);
            Assert.AreEqual("C", columns[2].Name);
            Assert.AreEqual("D", columns[3].Name);
            Assert.AreEqual("E", columns[4].Name);
            Assert.AreEqual(3, columns[0].MergeColNumber);
            Assert.AreEqual(4, columns[1].MergeColNumber);
            Assert.AreEqual(0, columns[2].MergeColNumber);
            Assert.AreEqual(0, columns[3].MergeColNumber);
            Assert.AreEqual(5, columns[4].MergeColNumber);
            Assert.AreEqual(0, columns[0].ColumnIndex);
            Assert.AreEqual(3, columns[1].ColumnIndex);
            Assert.AreEqual(7, columns[2].ColumnIndex);
            Assert.AreEqual(8, columns[3].ColumnIndex);
            Assert.AreEqual(9, columns[4].ColumnIndex);
        }

        private List<Columns> CreateRowWithMergedColumn()
        {
            return new List<Columns>
            {
                new Columns { ColumnIndex = 0, Name = "A", MergeColNumber = 3 },
                new Columns { ColumnIndex = 3, Name = "B", MergeColNumber = 4 },
                new Columns { ColumnIndex = 7, Name = "C" },
                new Columns { ColumnIndex = 8, Name = "D" },
                new Columns { ColumnIndex = 9, Name = "E", MergeColNumber = 5 }
            };
        }
    }
}
