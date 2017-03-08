using System;
using Fanex.Data.Repository;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.DatabaseTests.TestCases;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.DatabaseTests
{
    public class DynamicRepositoryTests
    {
        [Test]
        [Category("RepositoryTests")]
        [TestCaseSource(typeof(CriteriaTestCases), "CriteriaCases")]
        public void Fetch_Successful(ICriteria criteria)
        {
            var repository = new DynamicRepository();
            var rs = repository.Fetch<SummaryModel>(criteria);
        }
    }
}