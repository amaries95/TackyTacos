using Menu.Data;
using Menu.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Menu
{
    public static class MenuServiceCollection
    {
        public static IServiceCollection AddMenu(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<TackyTacosDbContext>(options => options.UseSqlServer(config.GetConnectionString("TackTacos")));
            services.AddScoped<MenuRepository>();
            services.AddScoped<MenuService>();

            return services;
        }
    }
}
