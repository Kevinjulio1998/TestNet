using Dummy.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Dummy.Infrastructure.Injection
{
    public class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IPeopleServices, PeopleServices>();
        }
    }
}
