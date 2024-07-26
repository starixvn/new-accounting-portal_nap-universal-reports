using Epplus.Mapper.Annotations;
using System;
using System.Collections.Generic;

namespace UniversalReports.ResultAnalysis.Models
{
    public class ResultAnalysisOfQuarterExcelModel
    {
        public IEnumerable<DetailedResultAnalysisOfQuarterExcelModel> Items { get; set; }

        public ResultAnalysisSummaryOfQuarterExcelModel Summary { get; set; }
    }

    public class ResultAnalysisSummaryOfQuarterExcelModel
    {
        [Cell("A6:B6")]
        public int TotalLeague { get; set; }

        [Cell("C6")]
        public int TotalMatch { get; set; }

        [Cell("D6")]
        public int FavHdpResult { get; set; }

        [Cell("E6")]
        public int UnderdogHdpResult { get; set; }

        [Cell("F6")]
        public int DrawHdpResult { get; set; }

        [Cell("G6")]
        public int OverOuResult { get; set; }

        [Cell("H6")]
        public int UnderOuResult { get; set; }

        [Cell("I6")]
        public int DrawOuResult { get; set; }

        [Cell("J6")]
        public int Fav1x2Result { get; set; }

        [Cell("K6")]
        public int Underdog1x2Result { get; set; }

        [Cell("L6")]
        public int Draw1x2Result { get; set; }
    }

    public class DetailedResultAnalysisOfQuarterExcelModel
    {
        [Cell("A10")]
        public DateTime Date { get; set; }

        [Cell("B10")]
        public string League { get; set; }

        [Cell("C10")]
        public string Match { get; set; }

        public string HDP { get; set; }

        [Cell("D10")]
        public string HdpString => HDP == "-" ? "-" : Math.Round(decimal.Parse(HDP), 2).ToString();

        public string OU { get; set; }

        [Cell("E10")]
        public string OuString => OU == "-" ? "-" : Math.Round(decimal.Parse(OU), 2).ToString();

        [Cell("F10")]
        public string Fav { get; set; }

        [Cell("G10")]
        public string Q1 { get; set; }

        [Cell("H10")]
        public string Q2 { get; set; }

        [Cell("I10")]
        public string Q3 { get; set; }

        [Cell("J10")]
        public string Q4 { get; set; }

        [Cell("K10")]
        public string OT { get; set; }

        [Cell("L10")]
        public string HtScore { get; set; }

        [Cell("M10")]
        public string H2Score { get; set; }

        [Cell("N10")]
        public string FtScore { get; set; }

        [Cell("O10")]
        public string ResultHDP { get; set; }

        [Cell("P10")]
        public string ResultOU { get; set; }

        [Cell("Q10")]
        public string ResultML{ get; set; }

        [Cell("R10")]
        public string HtWM { get; set; }

        [Cell("S10")]
        public string FtWM { get; set; }
    }
}
