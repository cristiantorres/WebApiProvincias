using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProvincias.Model;

namespace WebApiProvincias.Repositories
{
    public class UserRepository : IUserRepository
    {
         
        private List<User> _listUsers = new List<User>();

        public User GetUserByLogin(string username, string password)
        {
          return  _listUsers.FirstOrDefault(x => x.username == username && x.password == password);
        }


        public void InsertUser(User user)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public UserRepository()
        {
            this.loadData();
        }

        private void loadData()
        {
            _listUsers.AddRange( new List<User>()
            {
                new User(){username = "user001", nombre = "Luis" ,apellido="Perez",password="023ccc",mail="user01@gmail.com"},
                new User(){username = "user002", nombre = "Claudio" ,apellido="Perez",password="023ccc",mail="user02@gmail.com"},
                new User(){username = "cristian.torres", nombre = "Cristian" ,apellido="Torres",password="123456",mail="cristian.torres@gmail.com"},
                new User(){username = "rod.claudia", nombre = "Claudia" ,apellido="Rodríguez",password="xzq009",mail="rod.clau@gmail.com"},

            });
        }
        public IEnumerable<User> GetUsers()
        {
            return _listUsers;
        }


 
    }
}
