using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Products;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository:IRepository <long,Product>
    {
        EditProduct GetDetails (long id);

        List<ProductViewModel> Search(ProductSearchModel productSearch);

        List<ProductViewModel> GetProducts();
    }
}
 