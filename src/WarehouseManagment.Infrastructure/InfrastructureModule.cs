

using Autofac;
using Microsoft.EntityFrameworkCore;
using WarehouseManagment.Infrastructure.Data;

namespace WarehouseManagment.Infrastructure
{
    public sealed class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {  

            builder.RegisterAssemblyTypes(typeof(IInfrastructureAssemblyMarker).Assembly)
                .AsImplementedInterfaces();

            builder.RegisterType<WarehouseContext>()
                .InstancePerRequest();
        }
    }
}
