using System.Collections.Generic;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Discounts.ColleagueDiscounts;

//[Authorize(Roles = Roles.Administator)]
public class IndexModel : PageModel
{
    private readonly IColleagueDiscountApplication _colleagueDiscountApplication;

    private readonly IProductApplication _productApplication;
    public List<ColleagueDiscountViewModel> ColleagueDiscounts;
    public SelectList Products;
    public ColleagueDiscountSearchModel SearchModel;

    public IndexModel(IProductApplication ProductApplication,
        IColleagueDiscountApplication colleagueDiscountApplication)
    {
        _productApplication = ProductApplication;
        _colleagueDiscountApplication = colleagueDiscountApplication;
    }

    [TempData] public string Message { get; set; }

    public void OnGet(ColleagueDiscountSearchModel searchModel)
    {
        Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        ColleagueDiscounts = _colleagueDiscountApplication.Search(searchModel);
    }

    public IActionResult OnGetCreate()
    {
        var command = new DefineColleagueDiscount
        {
            Products = _productApplication.GetProducts()
        };
        return Partial("./Create", command);
    }

    public JsonResult OnPostCreate(DefineColleagueDiscount command)
    {
        var result = _colleagueDiscountApplication.Define(command);
        return new JsonResult(result);
    }

    public IActionResult OnGetEdit(long id)
    {
        var colleagueDiscount = _colleagueDiscountApplication.GetDetails(id);
        colleagueDiscount.Products = _productApplication.GetProducts();
        return Partial("Edit", colleagueDiscount);
    }

    public JsonResult OnPostEdit(EditColleagueDiscount command)
    {
        var result = _colleagueDiscountApplication.Edit(command);
        return new JsonResult(result);
    }

    public IActionResult OnGetRemove(long id)
    {
        _colleagueDiscountApplication.Remove(id);
        return RedirectToPage("./Index");
    }

    public IActionResult OnGetRestore(long id)
    {
        _colleagueDiscountApplication.Restore(id);
        return RedirectToPage("./Index");
    }
}