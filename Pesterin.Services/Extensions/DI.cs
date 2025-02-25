using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pesterin.Core.Uows;
using Pesterin.Infrastructure.Uows;
using Pesterin.Services.Impls;
using Pesterin.Services.Interface;

namespace Pesterin.Services.Extensions
{
    public static class DI
    {
        public static void Inject(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IArtService, ArtService>();
        }
    }
}
