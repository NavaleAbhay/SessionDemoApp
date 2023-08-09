using SessionDemo.Models;
using SessionDemo.Repositories;
namespace SessionDemo.Services;
public class ProductService:IProductService{

    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo){
        this._repo=repo;
    }
    public List<Product> GetAllProducts()=> _repo.GetAllProducts();

    public Product GetProductById(int id)=>_repo.GetProductById(id);
}