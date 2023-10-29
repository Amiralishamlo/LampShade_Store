using _01_LampshadeQuery;
using _01_LampshadeQuery.Contracts.ArticleCategory;
using _01_LampshadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents;

public class MenuViewComponent : ViewComponent
{
    private readonly IArticleCategoryQuery _articleCategoryQuery;
    private readonly IProductCategoryQuery _productCategoryQuery;

    public MenuViewComponent(IProductCategoryQuery productCategoryQuery, IArticleCategoryQuery articleCategoryQuery)
    {
        _articleCategoryQuery = articleCategoryQuery;
        _productCategoryQuery = productCategoryQuery;
    }

    public IViewComponentResult Invoke()
    {
        var result = new MenuModel
        {
            ArticleCategories = _articleCategoryQuery.GetArticleCategories(),
            ProductCategories = _productCategoryQuery.GetProductCategories()
        };
        return View(result);
    }
}