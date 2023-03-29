using Microsoft.EntityFrameworkCore;
using OrderService.Application;
using OrderService.BackgroundServices;
using OrderService.Data.Context;
using OrderService.Data.Repositories;
using OrderService.RabbitMQ;
using OrderService.RabbitMQ.Services;

namespace OrderService.Extensions;

public static class WebApplicationExtensions
{
    public static IServiceCollection AddAllServices(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddAutoMapper(typeof(Program));

        services.AddDbContext<OrderContext>(options =>
            options.UseInMemoryDatabase("order_db"),
            ServiceLifetime.Singleton
        );

        services.AddScoped<IOrderApplicationService, OrderApplicationService>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddHostedService<Worker>();

        services.AddScoped<IRabbitMqService, RabbitMqService>();
        services.AddScoped<RabbitMqClient>();

        return services;
    }

    public static WebApplication ConfigureWebApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        return app;
    }
}
