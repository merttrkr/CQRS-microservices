using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    //service registration 
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            //x.AddEntityFrameworkOutbox<BaseDbContext>(o =>
            //{
            //    o.QueryDelay = TimeSpan.FromSeconds(10);

            //    o.UsePostgres();
            //    o.UseBusOutbox();
            //});

            //x.AddConsumersFromNamespaceContaining<AuctionCreatedFaultConsumer>();

            //x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("auction", false));

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });
        return services;
    }

   


}
