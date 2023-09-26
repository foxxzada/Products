using Microsoft.EntityFrameworkCore;
using Products_API.Models;

namespace Products_API.Data;

public class WebDbContext : DbContext
{
    public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
    {
        
    }

    public DbSet<ProductModel> Products { get; set; }
}
