using System.Collections.Generic;
using QwestAPI.Models;

namespace QwestAPI.Services
{
    public interface IUserService
    {
        List<User> Get();
        User Get(string Id);
        User Create(User item);
        void Update(string Id, User item);
        void Remove(string id);
    }
}
