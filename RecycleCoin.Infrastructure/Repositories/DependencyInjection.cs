using Microsoft.Extensions.DependencyInjection;
using RecycleCoin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Infrastructure.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {

            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
