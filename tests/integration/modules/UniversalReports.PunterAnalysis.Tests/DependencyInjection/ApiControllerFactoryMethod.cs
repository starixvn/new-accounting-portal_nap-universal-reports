using Fanex.Data.Repository;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection.SimpleInjector;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection
{
    public abstract class ApiControllerFactoryMethod : IDisposable
    {
        private Container container = new Container();

        public virtual Controller CreateController<Controller, Model>(string fakeDatabaseFile)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            var repository = CreateRepository<Model>(fakeDatabaseFile);
            RegisterDependency(repository);

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

        protected abstract IDynamicRepository CreateRepository<Model>(string fakeDatabaseFile);

        protected void RegisterDependency(IDynamicRepository repository)
        {
            container.Register(() => repository);
            container.RegiserGlobalServices()
                    .RegisterPunterAnalysisServices()
                    .RegisterMediator();
            container.Verify();
        }
    }
}