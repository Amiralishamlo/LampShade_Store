using System.Collections.Generic;
using _01_LampshadeQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class SearchModel : PageModel
{
    private readonly IProductQuery _productQuery;
    public List<ProductQueryModel> Products;
    public string Value;

    public SearchModel(IProductQuery productQuery)
    {
        _productQuery = productQuery;
    }

    public void OnGet(string value)
    {
        Value = value;
        Products = _productQuery.Search(value);
    }
}