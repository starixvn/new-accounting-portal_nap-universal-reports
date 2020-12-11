using Fanex.Data.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using UniversalReports.DailyTurnoverComparison.Model;

namespace UniversalReports.DailyTurnoverComparison.Service
{
    public interface DataService
    {
        List<DataTable> Query(HttpRequestParameter httpPatam);
    }

    public class DataServiceImp : DataService
    {
        private readonly IDynamicRepository repository;

        public DataServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public List<DataTable> Query(HttpRequestParameter httpParam)
        {
            var tables = new List<DataTable>();
            try
            {
                var fileName = $@"D:\Fanex.Excel\DailyTurnoverComparison.JSON";
                if (File.Exists(fileName))
                {
                    var text = File.ReadAllText(fileName);
                    var source = JsonConvert.DeserializeObject<List<TurnoverModel>>(text);
                    tables = SeparateDataBySheet(source);
                }
                else
                {
                    var criteria = new Criteria { ToDate = new DateTime(2020, 11, 10), Top = httpParam.TopLicensees };
                    var result = repository.Fetch<TurnoverModel>(criteria).ToList();
                    var json = JsonConvert.SerializeObject(result, Formatting.Indented);
                    File.WriteAllText(fileName, json);
                }
            }
            catch (Exception ex)
            {
            }

            return tables;
        }

        private List<DataTable> SeparateDataBySheet(List<TurnoverModel> source)
        {
            var result = new List<DataTable>();
            var siteNames = source.Select(s => s.SiteName).Distinct().ToList();
            var rowPerBatch = 10;
            var totalBatch = siteNames.Count / rowPerBatch + ((siteNames.Count % rowPerBatch) > 0 ? 1 : 0);
            for (var batchIndex = 0; batchIndex < totalBatch; batchIndex++)
            {
                var sites = siteNames.Skip(batchIndex * rowPerBatch).Take(rowPerBatch).ToList();
                var dataBySite = source.Where(s => sites.Contains(s.SiteName)).OrderBy(o => o.RptDate).ToList();
                var dataTable = PivotDataBySite(sites, dataBySite);
                result.Add(dataTable);
            }

            return result;
        }

        private DataTable PivotDataBySite(List<string> sites, List<TurnoverModel> dataBySite)
        {
            var columns = new List<string> { "MemberTurnover", "TODiff", "ActiveMembers", "ActiveMemberDiff" };
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("RptDate", typeof(DateTime));
            dataTable.Columns.Add("WeekDays", typeof(string));
            sites.ForEach(site =>
            {
                for (var columnInex = 0; columnInex < columns.Count; columnInex++)
                {
                    dataTable.Columns.Add($"{site}|{columns[columnInex]}", typeof(decimal));
                }
            });

            dataBySite.GroupBy(g => new { RptDate = g.RptDate, WeekDays = g.WeekDays })
                .ToList()
                .ForEach(dataByDate =>
                {
                    var newRowByDate = dataTable.NewRow();
                    newRowByDate["RptDate"] = dataByDate.Key.RptDate;
                    newRowByDate["WeekDays"] = dataByDate.Key.WeekDays;
                    sites.ForEach(site =>
                    {
                        AssignValueToColumnBySite(newRowByDate, site, columns, dataByDate);
                    });

                    dataTable.Rows.Add(newRowByDate);
                });

            return dataTable;
        }

        private void AssignValueToColumnBySite(DataRow newRowByDate, string site, List<string> columns, IGrouping<dynamic, TurnoverModel> dataByDate)
        {
            for (var columnInex = 0; columnInex < columns.Count; columnInex++)
            {
                var columnName = $"{site}|{columns[columnInex]}";
                if (columns[columnInex] == "MemberTurnover")
                {
                    newRowByDate[columnName] = dataByDate.FirstOrDefault(s => s.SiteName == site).MemberTurnover;
                }
                else if (columns[columnInex] == "TODiff")
                {
                    var value = dataByDate.FirstOrDefault(s => s.SiteName == site).TODiff;
                    AssignValueToColumn(newRowByDate, columnName, value);
                }
                else if (columns[columnInex] == "ActiveMembers")
                {
                    newRowByDate[columnName] = dataByDate.FirstOrDefault(s => s.SiteName == site).ActiveMembers;
                }
                else if (columns[columnInex] == "ActiveMemberDiff")
                {
                    var value = dataByDate.FirstOrDefault(s => s.SiteName == site).ActiveMemberDiff;
                    AssignValueToColumn(newRowByDate, columnName, value);
                }
            }
        }

        private static void AssignValueToColumn(DataRow newRowByDate, string columnName, decimal? value)
        {
            if (value.HasValue)
            {
                newRowByDate[columnName] = value;
            }
            else
            {
                newRowByDate[columnName] = DBNull.Value;
            }
        }
    }
}