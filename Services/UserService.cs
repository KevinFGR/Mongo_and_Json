using Microsoft.Extensions.Options;
using Mongo.Api.Models;
using MongoDB.Driver;
using System.Text.Json;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

namespace Services;

public class UserService
{
    public IMongoCollection<object> _collection;
    public UserService(IOptions<MongoSettings> DBSettings){
        var mongoClient = new MongoClient(DBSettings.Value.ConnectionString);
        var mongoDb = mongoClient.GetDatabase(DBSettings.Value.DatabaseName);
        _collection = mongoDb.GetCollection<object>(DBSettings.Value.CollectionName);
    }
    public async Task<List<object>> GetAllUsers()
    {
        try
        {
            List<object> users = await _collection.Find(_ => true).ToListAsync();
            return users;
        }
        catch (Exception e)
        {

            throw new Exception($"Something wrong ocurred trying get all USer. USerService.cs GetAllUSer() \n\n {e.Message}");
        }
    }

    public async Task CreateUser(object user)
    {
        try
        {
            // user.Id = ObjectId.GenerateNewId();
              var objString = Convert.ToString(user);

              BsonDocument obj = BsonDocument.Parse(objString);

            //   var realState = new UserModel()
            //   {
            //       Data = obj,
            //   };


            // user.Attributes = user.Attributes.Deserialize<object>();
            await _collection.InsertOneAsync(obj);
        }
        catch (Exception e)
        {
            throw new Exception($"Something went wrong trying to Create USer on USerService.cs CreateUSer() \n\n{e.Message}");
        }
    }
}