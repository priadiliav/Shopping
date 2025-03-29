using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shopping.Api.Models;

public class Product
{
  [BsonId]
  [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
  public string Id { get; set; } = ObjectId.GenerateNewId().ToString(); // Generates valid ObjectId if not provided
  public string Name { get; set; }
  public string Description { get; set; }
  public decimal Price { get; set; }
  public string ImageFile { get; set; }
  public string Category { get; set; }
}
