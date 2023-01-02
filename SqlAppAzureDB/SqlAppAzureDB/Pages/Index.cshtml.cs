using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SqlAppAzureDB.Data.Models;
using SqlAppAzureDB.Data.Services;

namespace SqlAppAzureDB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }
        public List<Product> products = new List<Product>();
        public void OnGet()
        {
            products = _productService.GetProducts();
        }
    }
}