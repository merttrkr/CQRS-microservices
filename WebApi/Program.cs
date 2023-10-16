using Application;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using MassTransit;
using Persistence;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();

//builder.Services.AddDistributedMemoryCache();
builder.Services.AddStackExchangeRedisCache(opt=> opt.Configuration="localhost:6379");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddMassTransit(x =>
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
        cfg.Host(builder.Configuration["RabbitMq:Host"], "/", host =>
        {
            host.Username(builder.Configuration.GetValue("RabbitMq:Username", "guest"));
            host.Password(builder.Configuration.GetValue("RabbitMq:Password", "guest"));
        });

        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


if(app.Environment.IsProduction())
app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
