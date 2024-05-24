
using BagelBooking.Exceptions;
using BagelBooking.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BagelBooking.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly AppDbContext db;
        private IConfiguration _configuration;
        public UserRepository(AppDbContext db, IConfiguration configuration)
        {
            this.db = db;
            this._configuration = configuration;
        }
        public UserRepository(AppDbContext db)
        {
            this.db = db;
        }
        public int RegisterUser(User user)
        {

            db.Users.Add(user);
            return db.SaveChanges();

        }



        public int DeleteUser(int id)
        {
            User c = db.Users.Where(x => x.UserId == id).FirstOrDefault();
            db.Users.Remove(c);
            return db.SaveChanges();
        }

        public User GetUser(int id)
        {
            return db.Users.Where(x => x.UserId == id).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public int UpdateUser(int id, User user)
        {
            User c = db.Users.Where(x => x.UserId == id).FirstOrDefault();
            c.User_name = user.User_name;
            c.Phone_No = user.Phone_No;
            c.Email = user.Email;
            c.Password = user.Password;
            c.Role = user.Role;

            db.Entry<User>(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges();
        }
        public string Login(string email, string password)
        {
            var userExist = db.Users.FirstOrDefault(t => t.Email == email && t.Password == password);
            if (userExist != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
            new Claim("Email",userExist.Email),
            new Claim("UserId",userExist.UserId.ToString()),
            new Claim("DisplayName",userExist.User_name),
            new Claim("Role",userExist.Role)
        };
                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return null;
        }
    }
}
