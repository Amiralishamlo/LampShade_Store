using Microsoft.Extensions.DependencyInjection;

namespace ShopManagement.Infrastructure.Configuration
{
    public class ShopManegmantBoostrapper
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IProductCategoryApplication, > ();
        } 
    }
}
