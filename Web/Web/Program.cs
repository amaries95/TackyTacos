using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("FoodService", client =>
{
    client.BaseAddress = new Uri("https://localhost:7225/menu/");
});

builder.Services.AddHttpClient("OrderService", client =>
{
    client.BaseAddress = new Uri("https://localhost:7225/order/");
});

builder.Services.AddHttpClient("PaymentService", client =>
{
    client.BaseAddress = new Uri("https://localhost:7225/payment/");
});

await builder.Build().RunAsync();
