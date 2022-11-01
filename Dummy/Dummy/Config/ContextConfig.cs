using Dummy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dummy.Config
{
    public static class ContextConfig
    {
        public static void Setup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DummyContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
