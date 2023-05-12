using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payments.Data;
using Payments.Services;

namespace Payments
{
    public static class PaymentsServiceCollection
    {
        public static IServiceCollection AddPayments(this IServiceCollection services, IConfiguration config)
        {
            var configSection = config.GetSection("MongoDb");
            var storageSettings = new StorageSettings();
            configSection.Bind(storageSettings);
            services.AddSingleton<StorageSettings>(storageSettings);
            services.AddSingleton<TableDbContext>();
            services.AddHttpClient<PaymentService>();
            return services;
        }
    }
}
