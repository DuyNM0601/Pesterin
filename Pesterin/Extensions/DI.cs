using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pesterin.Exceptions;
using Pesterin.Infrastructure.Data;

namespace Pesterin.Extensions
{
    public static class DI
    {
        public static void InjectAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PesterinContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("PesterinDb")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionHadler>();
            });

        }
}
}
