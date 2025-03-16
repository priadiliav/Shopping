using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Shopping.Client.Data;
using Shopping.Client.Models;

namespace Shopping.Client.Controllers;

public class HomeController : Controller
{
  private readonly HttpClient _httpClient;
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
  {

    _httpClient = httpClientFactory.CreateClient("ShoppingAPIClient") ;
    _logger = logger;
  }

  public async Task<IActionResult> Index()
  {
    var response = await _httpClient.GetAsync("/api/products");
    var content = await response.Content.ReadAsStringAsync();
    
    var productList = JsonSerializer.Deserialize<IEnumerable<Product>>(content,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

    return View(productList);
  }

  public IActionResult Privacy()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}