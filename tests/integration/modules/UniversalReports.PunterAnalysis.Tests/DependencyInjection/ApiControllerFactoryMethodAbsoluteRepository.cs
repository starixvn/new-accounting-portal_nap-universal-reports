using Fanex.Data.Repository;
using SimpleInjector;
using System;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection.SimpleInjector;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection
{
    public sealed class ApiControllerFactoryMethodAbsoluteRepository : IDisposable
    {
        private readonly Container container = new Container();

        public TController CreateController<TController>(IDynamicRepository repository)
        {
            container.Register(() => repository);
            container.RegiserGlobalServices()
                    .RegisterMediator()
                    .RegisterAutoMapper()
                    .RegisterPunterAnalysisServices();
            container.Verify();

            return (TController)container.GetInstance(typeof(TController));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                container.Dispose();
            }
        }
    }
}