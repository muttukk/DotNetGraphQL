using SqlAppAzureDB.Data.Models;
using System.Data.SqlClient;

namespace SqlAppAzureDB.Data.Services
{
    public class ProductService
    {
        private static string db_source = "appserver3.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_password = "Azuredemo2022";
        private static string db_database = "appdb";

        private SqlConnection GetConnection()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = db_source;
            builder.UserID = db_user;
            builder.Password = db_password;
            builder.InitialCatalog = db_database;
            return new SqlConnection(builder.ConnectionString);
            // store this app in config file
            //"Data Source=appserver3.database.windows.net;Initial Catalog=appdb;User ID=sqladmin;Password=***********"
        }

        public List<Product> GetProducts()
        {
            SqlConnection connection = GetConnection();
            List<Product> products = new List<Product>();
            var query = "select id,Name,qauntity from products";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            using (SqlDataReader reader=cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    products.Add(new Product { 
                    
                    ID=reader.GetInt32(0),
                    Name=reader.GetString(1),
                    qauntity=reader.GetInt32(2)
                    });
                }
            }
            connection.Close();
            return products;
        }
    }
}
