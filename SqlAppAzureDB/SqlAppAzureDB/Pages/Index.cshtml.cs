using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SqlAppAzureDB.Data.Models;
using SqlAppAzureDB.Data.Services;

namespace SqlAppAzureDB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        public bool isBeta;
        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }
        public List<Product> products = new List<Product>();
        public void OnGet()
        {
            // Reads the value from the Azure Feature flag
            //isBeta = _productService.IsBeta().Result; 
            isBeta = true;
            products = _productService.GetProducts();
        }
    }
}