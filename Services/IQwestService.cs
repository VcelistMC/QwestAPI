using System.Collections.Generic;
using QwestAPI.Models;

namespace QwestAPI.Services
{
    public interface IQwestService
    {
        List<TodoItem> Get(string user_id);
        TodoItem Get(string user_id, string item_id);
        TodoItem Create(string user_id, TodoItem itemIn);
        TodoItem Update(string user_id, TodoItem itemIn);
        TodoItem Remove(string user_id, string id);
        
    }
}
