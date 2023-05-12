using KItchenLib;
using Menu;
using Orders;
using Payments;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>()
    .AddCommandLine(args)
    .Build();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:7045", "https://localhost:7166")
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .SetIsOriginAllowed((x) => true)
                           .AllowCredentials();
                      });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOrders(builder.Configuration);
builder.Services.AddHttpClient();
builder.Services.AddPayments(builder.Configuration);
builder.Services.AddMenu(builder.Configuration);
builder.Services.AddKitchen(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddMenuEndpoints();
app.AddOrderEndpoints();
app.AddKitchenApp();

app.UseRouting();
app.UseCors();

app.Run();
