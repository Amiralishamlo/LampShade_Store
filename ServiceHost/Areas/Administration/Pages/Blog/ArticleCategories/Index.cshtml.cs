using System.Collections.Generic;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Blog.ArticleCategories;

public class IndexModel : PageModel
{
    private readonly IArticleCategoryApplication _articleCategoryApplication;
    public List<ArticleCategoryViewModel> ArticleCategories;
    public ArticleCategorySearchModel SearchModel;

    public IndexModel(IArticleCategoryApplication articleCategoryApplication)
    {
        _articleCategoryApplication = articleCategoryApplication;
    }

    public void OnGet(ArticleCategorySearchModel searchModel)
    {
        ArticleCategories = _articleCategoryApplication.Search(searchModel);
    }

    public IActionResult OnGetCreate()
    {
        return Partial("./Create", new CreateArticleCategory());
    }

    public JsonResult OnPostCreate(CreateArticleCategory command)
    {
        var result = _articleCategoryApplication.Create(command);
        return new JsonResult(result);
    }

    public IActionResult OnGetEdit(long id)
    {
        var productCategory = _articleCategoryApplication.GetDetails(id);
        return Partial("Edit", productCategory);
    }

    public JsonResult OnPostEdit(EditArticleCategory command)
    {
        var result = _articleCategoryApplication.Edit(command);
        return new JsonResult(result);
    }
}