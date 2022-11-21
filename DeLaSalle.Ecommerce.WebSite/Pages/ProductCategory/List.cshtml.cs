using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeLaSalle.Ecommerce.WebSite.Pages.ProductCategory;

public class ListModel : PageModel
{
    private readonly IProductCategoryService _service;
    public List<ProductCategoryDto> ProductCategories { get; set; }
    
    public ListModel(IProductCategoryService service)
    {
        ProductCategories = new List<ProductCategoryDto>();
        _service = service;
    }

    public async Task<IActionResult> OnGet()
    {
        // Call to Service 
        var response = await _service.GetAllAsync();
        ProductCategories = response.Data;
        return Page();
    }
}