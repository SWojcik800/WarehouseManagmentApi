using Autofac;

namespace WarehouseManagment.Application
{
    public sealed class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IApplicationAssemblyMarker).Assembly)
                .AsImplementedInterfaces();
        }
    }
}
