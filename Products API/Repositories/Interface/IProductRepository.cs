using Products_API.Models;

namespace Products_API.Repositories.Interface;

public interface IProductRepository
{
    Task<List<ProductModel>> GetAllProducts();
    Task<ProductModel> GetProductById(int id);
    Task<ProductModel> AddProduct(ProductModel product);
    Task<ProductModel> UpdateProduct(ProductModel product, int id);
    Task<bool> DeleteProduct(int id);
}