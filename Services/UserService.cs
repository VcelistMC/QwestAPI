using QwestAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace QwestAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IQwestAPIDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.QwestCollectionName);
        }

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public List<User> Get()
        {
            List<User> users = _users.Find(item => true).ToList();
            return users;
        }

        public User Get(string Id) =>
            _users.Find(user => user.Id == Id).FirstOrDefault();

        public void Remove(string Id) =>
            _users.DeleteOne(user => user.Id == Id);

        public void Update(string Id, User item) =>
            _users.ReplaceOne(user => user.Id == Id, item);
    }
}