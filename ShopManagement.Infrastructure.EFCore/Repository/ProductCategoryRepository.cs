using _0_Framework.Infrastructure;
using ShopManagement.Application.Contracts.ProductCategorys;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long,ProductCategory> , IProductCategoryRepository
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }
        public EditProductCategory GetDetails(long id)
        {
            var query = _shopContext.ProductCategories.Select(x => new EditProductCategory()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
            });
            return query.FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel seachModel)
        {
            var query = _shopContext.ProductCategories.Select(x => new ProductCategoryViewModel()
            {
                Picture = x.Picture,
                CreateDate=x.CreationDate.ToString(),
                Id=x.Id, 
                Name=x.Name,
            });
            if (!string.IsNullOrWhiteSpace(seachModel.Name))
                query = query.Where(x => x.Name.Contains(seachModel.Name));

            return query.OrderBy(x=>x.Id).ToList();
        }
    }
}
