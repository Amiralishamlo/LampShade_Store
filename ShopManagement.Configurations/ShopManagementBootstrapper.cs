using _01_LampshadeQuerys.Contract.ProductCategory;
using _01_LampshadeQuerys.Contract.Slide;
using _01_LampshadeQuerys.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.ProductCategorys;
using ShopManagement.Application.Contracts.ProductPictures;
using ShopManagement.Application.Contracts.Products;
using ShopManagement.Application.Contracts.Slides;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SliderAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;

namespace ShopManagement.Configurations
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            services.AddTransient<ISlideApplication, SlideApplication>();
            services.AddTransient<ISlideRepository, SlideRepository>();

            services.AddTransient<ISlideQuery, SlideQuery>();
            services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
