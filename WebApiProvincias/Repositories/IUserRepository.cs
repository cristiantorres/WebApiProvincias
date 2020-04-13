using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProvincias.Model;

namespace WebApiProvincias.Repositories
{
   public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserByLogin(string username, string password);
        void InsertUser(User user);
        void UpdateUser(User user);
        void Save();
    }
}
