using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetSpeedTest.Infrastructure.Abstract;
using InternetSpeedTest.Infrastructure.Models.Entities;
using MongoDB.Driver;

namespace InternetSpeedTest.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;
        public UserRepository(IMongoCollection<User> userCollection)
        {
            _userCollection = userCollection;
        }
        public async Task CreateUserAsync(User user)
        {
            await _userCollection.InsertOneAsync(user);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userCollection.Find(_ => true).ToListAsync();
        }
    }
}