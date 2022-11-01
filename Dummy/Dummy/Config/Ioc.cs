using Dummy.Domain.IGeneric;
using Dummy.Infrastructure.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Dummy.Config
{
    public static class Ioc
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {

            services.AddScoped<IUnitContext, UnitContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
