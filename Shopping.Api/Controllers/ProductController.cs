
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Shopping.Api.Models;
using Shopping.Client.Data;

namespace Shopping.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
  public readonly ILogger<ProductController> _logger;
  public readonly ProductContext _context;
  public ProductController(ILogger<ProductController> logger, ProductContext productContext)
  {
    _context = productContext ;
    _logger = logger;
  }

  [HttpGet]
  public async Task<List<Product>> GetProducts ()
  {
    return await _context
                      .Products
                      .Find(p=>true)
                      .ToListAsync();
  }
}
