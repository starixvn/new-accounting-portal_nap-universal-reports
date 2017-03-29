using Fanex.Data.Repository;
using SimpleInjector;
using System;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection.SimpleInjector;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection
{
    public class SimpleInjectorTest : IDisposable
    {
        private readonly Container container = new Container();

        public SimpleInjectorTest(IDynamicRepository repository)
        {
            container.Register(() => repository);
            container.RegiserGlobalServices()
                    .RegisterPunterAnalysisServices()
                    .RegisterMediator();
            container.Verify();
        }

        public object GetInstance(Type serviceType)
        {
            return container.GetInstance(serviceType);
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