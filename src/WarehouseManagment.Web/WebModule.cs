using Autofac;
using WarehouseManagment.Application;
using WarehouseManagment.Infrastructure;

namespace WarehouseManagment.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IWebAssemblyMarker).Assembly)
                .AsImplementedInterfaces();        
        }
    }
}