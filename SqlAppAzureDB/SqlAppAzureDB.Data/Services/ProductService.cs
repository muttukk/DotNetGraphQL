using Microsoft.Extensions.Configuration;
using SqlAppAzureDB.Data.Models;
using System.Data.SqlClient;

namespace SqlAppAzureDB.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("SqlConnection"));
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
