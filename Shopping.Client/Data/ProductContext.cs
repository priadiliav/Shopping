using Shopping.Client.Models;

namespace Shopping.Client.Data;

public static class ProductContext
{
  public static readonly List<Product> Products = new()
  {
    new() { Id = "1", Name = "Soccer Ball", Description = "FIFA-approved size and weight", Price = 19.50m, ImageFile = "soccerball.png", Category = "Soccer" },
    new() { Id = "2", Name = "Tennis Ball", Description = "ITF-approved size and weight", Price = 4.50m, ImageFile = "tennisball.png", Category = "Tennis" },
    new() { Id = "3", Name = "Golf Ball", Description = "USGA-approved size and weight", Price = 2.50m, ImageFile = "golfball.png", Category = "Golf" },
    new() { Id = "4", Name = "Ping Pong Ball", Description = "Not approved for professional play", Price = 1.50m, ImageFile = "pingpongball.png", Category = "Ping Pong" },
    new() { Id = "5", Name = "Beach Ball", Description = "For fun in the sun", Price = 2.50m, ImageFile = "beachball.png", Category = "Beach" },
    new() { Id = "6", Name = "Basketball", Description = "NBA-approved size and weight", Price = 9.50m, ImageFile = "basketball.png", Category = "Basketball" },
    new() { Id = "7", Name = "Baseball", Description = "MLB-approved size and weight", Price = 5.50m, ImageFile = "baseball.png", Category = "Baseball" },
  };
  
  
}
