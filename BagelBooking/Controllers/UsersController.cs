using BagelBooking.Aspects;
using BagelBooking.Models;
using BagelBooking.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BagelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionHandler]
    [EnableCors("policy")]

    public class UsersController : ControllerBase
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }
        // GET: api/<UserController>

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetUsers());
        }

        // GET api/<UsersController>/5
        //[Authorize(Roles = "User")]
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(service.GetUser(id));
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post(User user)
        {
            return StatusCode(201, service.RegisterUser(user));
        }

        // PUT api/<UsersController>/5
        //[Authorize(Roles = "User")]
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, User user)
        {
            return Ok(service.UpdateUser(id, user));
        }

        // DELETE api/<UsersController>/5
        //[Authorize(Roles = "Admin,User")]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(service.DeleteUser(id));
        }
        [HttpPost("login")]
        public string UserLogin(string email, string password)
        {
            var result = service.Login(email, password);

            if (result != null)
            {
                return result;
            }
            return null;
        }
    }
}
