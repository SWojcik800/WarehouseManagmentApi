

using Autofac;

namespace WarehouseManagment.Infrastructure
{
    public sealed class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IInfrastructureAssemblyMarker).Assembly)
                .AsImplementedInterfaces();
        }
    }
}
