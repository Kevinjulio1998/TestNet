using System;
using Dummy.Infrastructure.Injection;
using Microsoft.Extensions.DependencyInjection;

namespace Dummy.Config
{
    public static class InjectionConfig
    {
        public static void InjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            DependencyInjection.RegisterServices(services);

        }
    }
}
