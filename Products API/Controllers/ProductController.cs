using Microsoft.AspNetCore.Mvc;
using Products_API.Models;
using Products_API.Repositories.Interface;

namespace Products_API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ProductController(IProductRepository productRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductModel>>> GetAll()
    {
        List<ProductModel> products = await productRepository.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("id")]
    public async Task<ActionResult<ProductModel>> GetById(int id)
    {
        ProductModel product = await productRepository.GetProductById(id);

        if (product == null)
            return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductModel>> AddProduct([FromBody] ProductModel newProduct)
    {
        ProductModel product = await productRepository.AddProduct(newProduct);
        return Ok(product);
    }

    [HttpPut("id")]
    public async Task<ActionResult<ProductModel>> UpdateProduct([FromBody] ProductModel product, int id)
    {
        product.Id = id;
        ProductModel updateProduct = await productRepository.UpdateProduct(product, id);
        return Ok(updateProduct);
    }

    [HttpDelete("id")]
    public async Task<ActionResult<bool>> DeleteProduct(int id)
    {
        bool product = await productRepository.DeleteProduct(id);
        return Ok(product);
    }
}