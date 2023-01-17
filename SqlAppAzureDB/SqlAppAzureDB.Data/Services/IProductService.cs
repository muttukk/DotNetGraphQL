using SqlAppAzureDB.Data.Models;

namespace SqlAppAzureDB.Data.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Task<bool> IsBeta();

        Task<List<Product>> GetProductsAsyncFromAzureFunction();
    }
}