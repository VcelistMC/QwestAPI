using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QwestAPI.Models
{
    public class TodoItem
    {
        [BsonId]
        public string Id { get; set; }
        public string desc { get; set; }
        public bool done { get; set; }
    }
}