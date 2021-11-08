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
        List<DataTable> Query(HttpRequestParameter httpParam);
    }

    public class DataServiceImp : DataService
    {
        private readonly DBService dBService;
        private readonly DateTimeService dateTimeService;
        private const int NumberOfLicenseePerSheet = 10;
        private const byte SixHour = 6;
        private const byte TwelveHour = 12;
        private const byte EighteenHour = 18;
        private const byte TwentyFourHour = 24;

        public DataServiceImp(DBService dBService, DateTimeService dateTimeService)
        {
            this.dBService = dBService;
            this.dateTimeService = dateTimeService;
        }

        private static Dictionary<int, string> HourFormat => new Dictionary<int, string>
        {
            { SixHour, "00:00-05:59" },
            { TwelveHour, "06:00-11:59" },
            { EighteenHour, "12:00-17:59" },
            { TwentyFourHour, "18:00-23:59" },
        };

        public List<DataTable> Query(HttpRequestParameter httpParam)
        {
            var source = dBService.Query(dateTimeService.ToDate, httpParam.TopLicensees);
            var tables = SeparateDataBySheet(source);

            return tables;
        }

        private List<DataTable> SeparateDataBySheet(List<TurnoverModel> source)
        {
            var result = new List<DataTable>();
            var siteNames = source.Select(s => s.SiteName).Distinct().ToList();
            const int rowPerBatch = NumberOfLicenseePerSheet;
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
            var hourFormat = HourFormat;
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

            dataBySite.GroupBy(g => new { RptDate = g.RptDate, WeekDays = g.WeekDays, Hour = g.Hour })
                .ToList()
                .ForEach(dataByDate =>
                {
                    var newRowByDate = dataTable.NewRow();
                    if (hourFormat.ContainsKey(dataByDate.Key.Hour))
                    {
                        newRowByDate["RptDate"] = hourFormat[dataByDate.Key.Hour];
                        newRowByDate["WeekDays"] = hourFormat[dataByDate.Key.Hour];
                    }
                    else
                    {
                        newRowByDate["RptDate"] = dataByDate.Key.RptDate;
                        newRowByDate["WeekDays"] = dataByDate.Key.WeekDays;
                    }

                    sites.ForEach(site =>
                    {
                        AssignValueToColumnBySite(newRowByDate, site, columns, dataByDate);
                    });

                    dataTable.Rows.Add(newRowByDate);
                });

            return dataTable;
        }

        private static void AssignValueToColumnBySite(DataRow newRowByDate, string site, List<string> columns, IGrouping<dynamic, TurnoverModel> dataByDate)
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
#pragma warning disable S126 // "if ... else if" constructs should end with "else" clauses
                else if (columns[columnInex] == "ActiveMemberDiff")
#pragma warning restore S126 // "if ... else if" constructs should end with "else" clauses
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