using SimpleInjector;
using UniversalReports.ActualMemberBet.Bettype;
using UniversalReports.ActualMemberBet.Common;
using UniversalReports.ActualMemberBet.Product;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class ActualMemberBetInjector
    {
        internal static Container RegisterActualMemberBetServices(this Container container)
        {
            container.Register<ActualMemberBetService, ActualMemberBetServiceImp>();
            container.Register<ProductExcelBuilder, ProductExcelBuilderImp>();
            container.Register<BettypeExcelBuilder, BettypeExcelBuilderImp>();
            return container;
        }
    }
}