using System;
using Microsoft.Extensions.DependencyInjection;

namespace Dummy.Config
{
    public static class MapperConfig
    {

        public static void AutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
