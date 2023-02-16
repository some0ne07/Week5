using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WebAPI.Models
{
    public class UserDb
    {
        private readonly IMongoCollection<UserData> collection;

        public UserDb()
        {
            var client = new MongoClient("mongodb://127.0.0.1:27017/");
            var database = client.GetDatabase("usersDB");
            collection = database.GetCollection<UserData>("UserDetails");
        }

        public async Task<List<UserData>> GetAll()
        {
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task<UserData> Get(string id)
        {
            return await collection.Find(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task Add(UserData user)
        {
            await collection.InsertOneAsync(user);
        }

        public async Task Update(UserData user)
        {
            await collection.ReplaceOneAsync(x => x.id == user.id, user);
        }
        public async Task Delete(string id)
        {
            await collection.DeleteOneAsync(x => x.id == id);
        }
    }
}
