using System.Collections.Generic;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Discounts.CustomerDiscounts;

//[Authorize(Roles = Roles.Administator)]
public class IndexModel : PageModel
{
    private readonly ICustomerDiscountApplication _customerDiscountApplication;

    private readonly IProductApplication _productApplication;
    public List<CustomerDiscountViewModel> CustomerDiscounts;
    public SelectList Products;
    public CustomerDiscountSearchModel SearchModel;

    public IndexModel(IProductApplication ProductApplication, ICustomerDiscountApplication customerDiscountApplication)
    {
        _productApplication = ProductApplication;
        _customerDiscountApplication = customerDiscountApplication;
    }

    [TempData] public string Message { get; set; }

    public void OnGet(CustomerDiscountSearchModel searchModel)
    {
        Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        CustomerDiscounts = _customerDiscountApplication.Search(searchModel);
    }

    public IActionResult OnGetCreate()
    {
        var command = new DefineCustomerDiscount
        {
            Products = _productApplication.GetProducts()
        };
        return Partial("./Create", command);
    }

    public JsonResult OnPostCreate(DefineCustomerDiscount command)
    {
        var result = _customerDiscountApplication.Define(command);
        return new JsonResult(result);
    }

    public IActionResult OnGetEdit(long id)
    {
        var customerDiscount = _customerDiscountApplication.GetDetails(id);
        customerDiscount.Products = _productApplication.GetProducts();
        return Partial("Edit", customerDiscount);
    }

    public JsonResult OnPostEdit(EditCustoemrDiscount command)
    {
        var result = _customerDiscountApplication.Edit(command);
        return new JsonResult(result);
    }
}