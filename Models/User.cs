using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace QwestAPI.Models
{
    public class User
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int totalItems { get; set; }
        public int completedItems { get; set; }
        public List<TodoItem> items { get; set; }
    }
}