using BagelBooking.Models;

namespace BagelBooking.Repository
{
    public interface IUserRepository
    {
        public List<User> GetUsers();
        User GetUser(int id);
        int RegisterUser(User user);
        int UpdateUser(int id, User user);
        int DeleteUser(int id);
        string Login(string email, string password);
    }
}
