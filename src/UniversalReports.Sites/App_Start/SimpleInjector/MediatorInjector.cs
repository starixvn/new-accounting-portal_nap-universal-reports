using MediatR.SimpleInjector;
using SimpleInjector;
using System.Collections.Generic;
using System.Reflection;
using UniversalReports.AbnormalBet;
using UniversalReports.ActualMemberBet;
using UniversalReports.CashOutPerformance;
using UniversalReports.Exchange;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.ResultAnalysis;
using UniversalReports.SBCustomerPerformanceByDanger;
using UniversalReports.SBPerformance;
using UniversalReports.SMAWinLoss;
using UniversalReports.UpdatedUsernameCredit;

namespace UniversalReports.Sites.SimpleInjector
{
    public static class MediatorInjector
    {
        public static Container RegisterMediator(this Container container)
        {
            var assemblies = GetAssemblies();
            return container.BuildMediator(assemblies);
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(PunterAnalysisAttribute).GetTypeInfo().Assembly;
            yield return typeof(UpdatedUsernameAndCreditAttribute).GetTypeInfo().Assembly;
            yield return typeof(ExchangeAttribute).GetTypeInfo().Assembly;
            yield return typeof(ActualMemberBetAttribute).GetTypeInfo().Assembly;
            yield return typeof(AbnormalBetAttribute).GetTypeInfo().Assembly;
            yield return typeof(SBPerformanceAttribute).GetTypeInfo().Assembly;
            yield return typeof(SMAWinLossAttribute).GetTypeInfo().Assembly;
            yield return typeof(SBCustomerPerformanceByDangerAttribute).GetTypeInfo().Assembly;
            yield return typeof(CashOutPerformanceAttribute).GetTypeInfo().Assembly;
            yield return typeof(ResultAnalysisAttribute).GetTypeInfo().Assembly;
		}
    }
}