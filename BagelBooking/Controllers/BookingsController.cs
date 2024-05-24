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
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService service;

        public BookingsController(IBookingService service)
        {
            this.service = service;
        }
        // GET: api/<UserController>
       // [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetBookings());
        }

        // GET api/<BookingsController>/5
        //[Authorize(Roles = "Admin,User")]
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(service.GetBooking(id));
        }

        // POST api/<BookingsController>
        //[Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Post(Booking booking)
        {
            return StatusCode(201, service.AddBooking(booking));
        }

        // PUT api/<BookingsController>/5
        //[Authorize(Roles ="User")]
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, Booking booking)
        {
            return Ok(service.UpdateBooking(id, booking));
        }

        // DELETE api/<BookingsController>/5
        //[Authorize(Roles = "Admin,User")]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(service.DeleteBooking(id));
        }
        //[Authorize(Roles = "User")]
        [HttpGet]
        [Route("{roomType}/{no}/{checkin}/{checkout}/TotalPrice")]
        public IActionResult TotalPrice(string roomType, int no, DateTime checkin, DateTime checkout)
        {
            return Ok(service.TotalPrice(roomType, no, checkin, checkout));
        }
        //[Authorize(Roles = "User")]
        [HttpGet]
        [Route("{id}/ChangePaymentStatus")]
        public IActionResult ChangePaymentStatus(int id)
        {
            return Ok(service.ChangePaymentStatus(id));
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetPastBookings")]
        public IActionResult GetPastBookings()
        {
            return Ok(service.GetPastBookings());
        }

    }
}
