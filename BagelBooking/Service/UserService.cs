using BagelBooking.Exceptions;
using BagelBooking.Models;
using BagelBooking.Repository;

namespace BagelBooking.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository repo;
        public UserService(IUserRepository repo)
        {

            this.repo = repo;
        }

        public int RegisterUser(User user)
        {

            if (repo.GetUser(user.UserId) != null)
            {
                throw new UserAlreadyExistsException($"Product with Product id {user.UserId} already exists");
            }
            return repo.RegisterUser(user);
        }

        public int DeleteUser(int id)
        {
            if (repo.GetUser(id) == null)
            {
                throw new UserNotFoundException($"Product with Product id {id} not Found");
            }
            return repo.DeleteUser(id);
        }

        public User GetUser(int id)
        {
            User c = repo.GetUser(id);
            if (c == null)
            {
                throw new UserNotFoundException($"Product with Product id {id} does not exists");
            }
            return c;
        }

        public List<User> GetUsers()
        {
            return repo.GetUsers();
        }

        public int UpdateUser(int id, User user)
        {
            if (repo.GetUser(id) == null)
            {
                throw new UserNotFoundException($"Product with Product id {id} does not exists");
            }
            return repo.UpdateUser(id, user);
        }
        public string Login(string email, string password)
        {
            return repo.Login(email, password);
        }
    }
}

