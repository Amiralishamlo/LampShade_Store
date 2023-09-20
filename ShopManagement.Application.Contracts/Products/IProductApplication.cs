using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.Products
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct create);

        OperationResult Edit(EditProduct edit);

        EditProduct GetDetails(long id);

        List<ProductViewModel> Search(ProductSearchModel searchModel);

        OperationResult IsStock(long id);

        OperationResult NotIsStock(long id);

        List<ProductViewModel> GetProducts();

    }
}
