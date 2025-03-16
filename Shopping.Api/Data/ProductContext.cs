using MongoDB.Driver;
using Shopping.Api.Models;

namespace Shopping.Client.Data;

public class ProductContext
{
  public IMongoCollection<Product> Products { get; }

  public ProductContext(IConfiguration configuration)
  {
    var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
    var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
    Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
    Seed(Products).GetAwaiter().GetResult(); // Викликаємо асинхронний метод синхронно в конструкторі
  }

  private async static Task Seed(IMongoCollection<Product> products)
  {
    long count = await products.CountDocumentsAsync(FilterDefinition<Product>.Empty);
    if (count == 0)
    {
      await products.InsertManyAsync(GetPreconfiguredProducts());
    }
  }

  public static List<Product> GetPreconfiguredProducts()
  {
    return new List<Product>()
    {
        new() { Name = "Soccer Ball", Description = "FIFA-approved size and weight", Price = 19.50m, ImageFile = "soccerball.png", Category = "Soccer" },
        new() { Name = "Tennis Ball", Description = "ITF-approved size and weight", Price = 4.50m, ImageFile = "tennisball.png", Category = "Tennis" },
        new() { Name = "Golf Ball", Description = "USGA-approved size and weight", Price = 2.50m, ImageFile = "golfball.png", Category = "Golf" },
        new() { Name = "Ping Pong Ball", Description = "Not approved for professional play", Price = 1.50m, ImageFile = "pingpongball.png", Category = "Table Tennis" }
    };
  }
}
