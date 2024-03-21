using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PhoenixIot.Core.Options;
using PhoenixIot.Entities;

namespace PhoenixIot;

public class UserService
{
    private IMongoCollection<User> _collection;

    public UserService(IOptions<MongoDbOptions> mongoDbOptions)
    {
        const string collectionName = "Users";
        MongoClient client = new MongoClient(mongoDbOptions.Value.ConnectionString);
        IMongoDatabase? database = client.GetDatabase(mongoDbOptions.Value.Database);
        var collection = database.GetCollection<User>(collectionName);
        if (collection == null)
        {
            database.CreateCollection(collectionName);
        }

        _collection = database.GetCollection<User>(collectionName);
    }

    public async Task CreateUser(User user) => await _collection.InsertOneAsync(user);

    public async Task<User?> IsUserExistByDate(DateTime createdAt) =>
        await _collection.Find(x => x.CreatedAt == createdAt)
            .FirstOrDefaultAsync();
}