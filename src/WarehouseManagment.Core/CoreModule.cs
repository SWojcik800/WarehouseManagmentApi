

using Autofac;
using WarehouseManagment.Core;

namespace WarehouseManagment.Infrastructure
{
    public sealed class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {  

            builder.RegisterAssemblyTypes(typeof(ICoreAssemblyMarker).Assembly)
                .AsImplementedInterfaces();
        }
    }
}
