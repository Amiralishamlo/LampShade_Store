using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.ProductCategorys
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);

        OperationResult Edit (EditProductCategory command);

        EditProductCategory GetDetails(long id);

        List<ProductCategoryViewModel> Search(ProductCategorySearchModel seachModel);

        List<ProductCategoryViewModel> GetProductCategorys();

    }
}
