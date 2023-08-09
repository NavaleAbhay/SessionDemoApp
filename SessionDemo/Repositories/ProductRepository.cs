using SessionDemo.Models;
using MySql.Data.MySqlClient;
namespace SessionDemo.Repositories;
public class ProductRepository:IProductRepository{
      public static string conString = "server=localhost;port=3306;user=root;password=password;database=db";

        public List<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM products";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Int32.Parse(reader["productId"].ToString());
                string? name = reader["name"].ToString();
                string? description = reader["description"].ToString();
                double unitPrice =double.Parse( reader["unitPrice"].ToString());
                int quantity =Int32.Parse( reader["quantity"].ToString());
                double amount = double.Parse(reader["totalAmount"].ToString());
                Product product = new Product()
                {
                    ID = id,
                    ProductName = name,
                    Description = description,
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    Amount = amount
                };

                products.Add(product);
            }
            reader.Close();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return products;

    }

    
    public Product GetProductById(int id)
    {
        Product product = new Product();
        
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM products where productId=" + id;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {   
                int newid = Int32.Parse(reader["productId"].ToString());
                string? name = reader["name"].ToString();
                string? description = reader["description"].ToString();
                double unitPrice =double.Parse( reader["unitPrice"].ToString());
                int quantity =Int32.Parse( reader["quantity"].ToString());
                double amount = double.Parse(reader["totalAmount"].ToString());
                 product = new Product()
                {
                   ID = newid,
                    ProductName = name,
                    Description = description,
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    Amount = amount
                };

            }
            reader.Close();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }

        return product;
    }
}