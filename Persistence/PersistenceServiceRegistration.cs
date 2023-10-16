using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("nArchitecture"));
        
        //services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("local")));
        services.AddDbContext<BaseDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("psqlserver")));
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IModelRepository, ModelRepository>();

        return services;
    }
}
