namespace Mongo.Api.Models;
public class MongoSettings
{
    public string ConnectionString { get; set; } = "mongodb://localhost:27017";

    public string DatabaseName { get; set; } = "jsonTest";

    public string CollectionName { get; set; } =  "test";
}