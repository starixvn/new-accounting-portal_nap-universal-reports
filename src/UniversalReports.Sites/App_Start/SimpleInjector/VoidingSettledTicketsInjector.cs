using SimpleInjector;
using UniversalReports.VoidingSettledTickets.Services;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class VoidingSettledTicketsInjector
    {
        internal static Container RegisterVoidingSettledTicketsServices(this Container container)
        {
            container.Register<VoidingSettledService, VoidingSettledServiceImp>();
            return container;
        }
    }
}