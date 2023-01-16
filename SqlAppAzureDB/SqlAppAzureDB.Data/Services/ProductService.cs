using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using SqlAppAzureDB.Data.Models;
using System.Data.SqlClient;

namespace SqlAppAzureDB.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        private readonly IFeatureManager _featureManager;
        public ProductService(IConfiguration configuration,IFeatureManager featureManager)
        {
            _featureManager = featureManager;
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("SqlConnection"));
            // below code while reading from Azure App config
            //return new SqlConnection(_configuration["SqlConnection"]);
        }

        public async Task<bool> IsBeta()
        {
            // Flag we added in Azure FF
            if (await _featureManager.IsEnabledAsync("beta"))
            {
                return true;
            }
            return false;
        }

        public List<Product> GetProducts()
        {
            SqlConnection connection = GetConnection();
            List<Product> products = new List<Product>();
            var query = "select id,Name,qauntity from products";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    products.Add(new Product
                    {

                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        qauntity = reader.GetInt32(2)
                    });
                }
            }
            connection.Close();
            return products;
        }
    }
}
/* can add in seed method-out of scope
 * create table products
(
ID int,
Name varchar(1000),
qauntity int
)

insert into products values (3,'Monitors',150);

select id,Name,qauntity from products
 * */
