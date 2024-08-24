using MassTransit;
using Microsoft.Extensions.DependencyInjection;


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

            //x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("auction", false));

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });
        return services;
    }

   


}
