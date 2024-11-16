using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        User GetUserByUsername(string username);
        void CreateUser(User user);
        void DeleteUser(int id);
        void UpdateUser(User user);
        List<User> GetAllUsers();
    }
}
