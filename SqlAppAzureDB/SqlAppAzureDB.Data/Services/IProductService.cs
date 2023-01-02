using SqlAppAzureDB.Data.Models;

namespace SqlAppAzureDB.Data.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}