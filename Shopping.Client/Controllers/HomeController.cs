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

    if (!response.IsSuccessStatusCode)
    {
        _logger.LogError("API call failed with status code: {StatusCode}", response.StatusCode);
        return View(new List<Product>());
    }

    var content = await response.Content.ReadAsStringAsync();
    
    if (string.IsNullOrWhiteSpace(content))
    {
        _logger.LogError("API response is empty.");
        return View(new List<Product>());
    }

    try
    {
        var productList = JsonSerializer.Deserialize<IEnumerable<Product>>(content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return View(productList);
    }
    catch (JsonException ex)
    {
        _logger.LogError(ex, "Error deserializing response content.");
        return View(new List<Product>());
    }
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