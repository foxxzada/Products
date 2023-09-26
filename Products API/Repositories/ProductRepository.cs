using Microsoft.EntityFrameworkCore;
using Products_API.Data;
using Products_API.Models;
using Products_API.Repositories.Interface;

namespace Products_API.Repositories;

public class ProductRepository :  IProductRepository
{
    private readonly WebDbContext _context;
    public ProductRepository(WebDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<ProductModel>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<ProductModel> GetProductById(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ProductModel> AddProduct(ProductModel product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<ProductModel> UpdateProduct(ProductModel product, int id)
    {
        ProductModel foundProduct = await GetProductById(id);

        if (foundProduct == null)
            throw new Exception("Product Not Found.");

        _context.Entry(foundProduct).CurrentValues.SetValues(product);
        _context.Products.Update(foundProduct);
        await _context.SaveChangesAsync();
        return foundProduct;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        ProductModel foundProduct = await GetProductById(id);

        if (foundProduct == null)
            throw new Exception("Product Not Found.");

        _context.Products.Remove(foundProduct);
        await _context.SaveChangesAsync();
        return true;
    }
}