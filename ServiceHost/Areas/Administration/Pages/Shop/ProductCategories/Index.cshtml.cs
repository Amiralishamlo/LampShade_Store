using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategorys;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel searchModel;

        public List<ProductCategoryViewModel> productCategories;
        private readonly IProductCategoryApplication _productCategory;

        public IndexModel(IProductCategoryApplication productCategory)
        {
            _productCategory = productCategory;
        }

        public void OnGet(ProductCategorySearchModel searchModel)
        {
            productCategories= _productCategory.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }

        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var result = _productCategory.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _productCategory.GetDetails(id);
            return Partial("Edit", productCategory);
        }

        public JsonResult OnPostEdit(EditProductCategory command)
        {
            var result = _productCategory.Edit(command);
            return new JsonResult(result);
        }
    }
}
