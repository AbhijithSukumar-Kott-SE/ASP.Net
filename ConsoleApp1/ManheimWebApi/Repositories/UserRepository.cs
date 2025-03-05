using ManheimWebApi.Configuration;
using ManheimWebApi.Models;
using ManheimWebApi.Repositories.interfaces;
using MongoDB.Driver;

namespace ManheimWebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _usersCollection;
        public UserRepository(MongoDbService mongoService)
        {
          
            _usersCollection = mongoService.GetCollection<User>("users");

        }

        public async Task CreateUserAsync(User user)
        {
            await _usersCollection.InsertOneAsync(user);
            
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var result = await _usersCollection.DeleteOneAsync(u => u.Id == id);
            return result.DeletedCount > 0;
        }

        public async Task<List<User>?> GetAllUsersAsync()
        {
            return await _usersCollection.Find(_ => true).ToListAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _usersCollection.Find(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByIdAsync(string id)
        {
            return await _usersCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateUserAsync(string id, User updatedUser)
        {
            var result = await _usersCollection.ReplaceOneAsync(u => u.Id == id, updatedUser);
            return result.ModifiedCount > 0;
        }
    }
}
