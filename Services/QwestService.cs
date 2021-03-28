using QwestAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace QwestAPI.Services
{
    public class QwestService : IQwestService
    {
        private readonly IMongoCollection<User> _items;

        public QwestService(IQwestAPIDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _items = database.GetCollection<User>(settings.QwestCollectionName);
        }

        public List<TodoItem> Get(string user_id)
        {
            User user = _items.Find(user => user.Id == user_id).FirstOrDefault();
            return (user == null)? null : user.items; 
        }

        public TodoItem Get(string user_id, string item_id)
        {
            User user = _items.Find(user => user.Id == user_id).FirstOrDefault();
            if(user == null)
                return null;
            foreach(TodoItem item in user.items)
            {
                if(item.Id == item_id)
                    return item;
            }
            return null;
        }

        public TodoItem Create(string user_id, TodoItem itemIn)
        {
            User user = _items.Find(user => user.Id == user_id).FirstOrDefault();
            if(user == null)
                return null;
            
            itemIn.Id = user_id + "-" + (++user.totalItems).ToString();
            user.items.Add(itemIn);
            _items.ReplaceOne(user => user.Id == user_id, user);
            return itemIn;
        }

        public TodoItem Update(string user_id, TodoItem itemIn)
        {
            User user = _items.Find(user => user.Id == user_id).FirstOrDefault();
            if(user == null)
                return null;
            
            user.items[user.items.Count - 1] = itemIn;
            _items.ReplaceOne(user => user.Id == user_id, user);
            return itemIn;
        }

        public TodoItem Remove(string user_id, string id)
        {
            User user = _items.Find(user => user.Id == user_id).FirstOrDefault();
            if(user == null)
                return null;
            
            TodoItem itemToBeRemoved = user.items.Find(item => item.Id == id);
            user.items.Remove(itemToBeRemoved);
            _items.ReplaceOne(user => user.Id == user_id, user);

            return itemToBeRemoved;
        }
    }
}
