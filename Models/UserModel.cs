using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Api.Models;
public class UserModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string? Name { get; set; }

    [BsonElement("attributes")]
    public object? Attributes { get; set; }
}