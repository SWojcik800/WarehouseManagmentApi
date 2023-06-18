using Autofac;
using WarehouseManagment.Application;
using WarehouseManagment.Core;
using WarehouseManagment.Infrastructure;

namespace WarehouseManagment.Api
{
    public sealed class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            System.Reflection.Assembly[] IoCAssemblies = {
                typeof(IApplicationAssemblyMarker).Assembly,
                typeof(IInfrastructureAssemblyMarker).Assembly,
                typeof(ICoreAssemblyMarker).Assembly,
            };


            builder.RegisterAssemblyModules(IoCAssemblies);            
        }
    }
}
