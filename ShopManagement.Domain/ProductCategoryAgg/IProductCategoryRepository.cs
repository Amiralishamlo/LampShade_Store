using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductCategorys;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository: IRepository<long,ProductCategory>
    {

        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel seachModel);
    }
}
