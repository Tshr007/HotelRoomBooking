using BagelBooking.Models;

namespace BagelBooking.Service
{
    public interface IUserService
    {
        public List<User> GetUsers();
        User GetUser(int id);
        int RegisterUser(User user);
        int UpdateUser(int id, User user);
        int DeleteUser(int id);
        string Login(string email, string password);
    }
}
