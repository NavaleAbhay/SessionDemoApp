using System.Net.Http.Headers;
using SessionDemo.Models;
namespace SessionDemo.Repositories;
public interface IProductRepository{
    List<Product> GetAllProducts();

    Product GetProductById(int id);
}
