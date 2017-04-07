using Fanex.Data.Repository;
using SimpleInjector;
using System;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection.SimpleInjector;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection
{
    public class ApiControllerFactoryMethodAbsoluteRepository : IDisposable
    {
        private readonly Container container = new Container();

        public virtual Controller CreateController<Controller>(IDynamicRepository repository)
        {
            container.Register(() => repository);
            container.RegiserGlobalServices()
                    .RegisterPunterAnalysisServices()
                    .RegisterMediator();
            container.Verify();

            return (Controller)container.GetInstance(typeof(Controller));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                container.Dispose();
            }
        }
    }
}