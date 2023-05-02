using Autofac;
using Mapster;
using MapsterMapper;

namespace WarehouseManagment.Application
{
    public sealed class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IApplicationAssemblyMarker).Assembly)
                .AsImplementedInterfaces();

            var config = new TypeAdapterConfig();
            config.Scan(typeof(IApplicationAssemblyMarker).Assembly);

            builder.RegisterInstance(config)
                .AsSelf()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<ServiceMapper>()
                .As<IMapper>();
        }
    }
}
