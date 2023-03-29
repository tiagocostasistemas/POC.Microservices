using Microsoft.EntityFrameworkCore;
using ProductService.Application;
using ProductService.BackgroundServices;
using ProductService.Data.Contexts;
using ProductService.Data.Repositories;
using ProductService.RabbitMQ;

namespace ProductService.Extensions;

public static class WebApplicationExtensions
{
    public static IServiceCollection AddAllServices(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddAutoMapper(typeof(Program));

        services.AddDbContext<ProductContext>(options =>
            options.UseInMemoryDatabase("product_db"),
            ServiceLifetime.Scoped
        );

        services.AddScoped<IProductApplicationService, ProductApplicationService>();
        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddHostedService<Worker>();
        services.AddSingleton<IRabbitMqBackgroundService, RabbitMqBackgroundService>();
        
        services.AddScoped<IRabbitMqService, RabbitMqService>();
        services.AddSingleton<RabbitMqClient>();

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
