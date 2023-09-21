using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductPictures;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductPictureRepository: RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _shopContext;

        public ProductPictureRepository(ShopContext shopContext):base(shopContext) 
        {
            _shopContext = shopContext;
        }

        public EditProductPicture GetDetails(long id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _shopContext.ProductPictures.Select(x => new EditProductPicture
            {
                Id = x.Id,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                ProductId=x.ProductId

            }).FirstOrDefault(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var query = _shopContext.ProductPictures.Include(x=>x.Product).Select(x => new ProductPictureViewModel
            {
                Id=x.Id,
                Picture=x.Picture,
                CreationDate=x.CreationDate.ToFarsi(),
                Product=x.Product.Name,
                ProductId=x.ProductId,
                IsRemoved=x.IsRemove
            });

            if (searchModel.ProductId != 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
