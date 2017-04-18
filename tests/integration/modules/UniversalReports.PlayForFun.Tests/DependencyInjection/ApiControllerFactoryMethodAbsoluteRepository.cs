using Fanex.Data.Repository;
using SimpleInjector;
using System;
using UniversalReports.PlayForFun.Tests.DependencyInjection.AutoMapperSettings.PlayForFun;
using UniversalReports.PlayForFun.Tests.DependencyInjection.SimpleInjector;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection
{
    public class ApiControllerFactoryMethodAbsoluteRepository : IDisposable
    {
        private readonly Container container = new Container();

        public virtual Controller CreateController<Controller>(IDynamicRepository repository)
        {
            PlayForFunAutoMapper.Initialize();

            container.Register(() => repository);
            container.RegiserGlobalServices()
                    .RegisterPlayForFunServices()
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