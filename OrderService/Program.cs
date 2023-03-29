using OrderService.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAllServices();

var app = builder.Build();
app.ConfigureWebApplication();

await app.RunAsync();
