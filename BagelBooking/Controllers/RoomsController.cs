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

    public class RoomsController : ControllerBase
    {
        private readonly IRoomService service;

        public RoomsController(IRoomService service)
        {
            this.service = service;
        }
        // GET: api/<RoomsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetRooms());
        }

        // GET api/<RoomsController>/5
        //[Authorize(Roles = "Admin,User")]
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(service.GetRoom(id));
        }

        // POST api/<RoomsController>
        //[Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult Post(Room room)
        {
            return StatusCode(201, service.AddRoom(room));

        }

        // PUT api/<RoomsController>/5
        //[Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, Room room)
        {
            return Ok(service.UpdateRoom(id, room));
        }

        // DELETE api/<RoomsController>/5
        //[Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(service.DeleteRoom(id));
        }
        //[Authorize(Roles = "User")]
        [HttpGet]
        [Route("{checkin}/{checkout}/RoomTypesAvailableOnDate")]
        public IActionResult RoomTypesAvailableOnDate(DateTime checkin, DateTime checkout, string roomType)
        {
            return Ok(service.RoomTypesAvailableOnDate(checkin, checkout, roomType));
        }
        //[Authorize(Roles = "User")]
        [HttpGet]
        [Route("{checkin}/{checkout}/RoomsAvailableOnDate")]
        public IActionResult RoomsAvailableOnDate(DateTime checkin, DateTime checkout)
        {
            return Ok(service.RoomsAvailableOnDate(checkin, checkout));

        }
        [HttpGet]
        [Route("{type}/IsRoomTypeAvailalble")]
        public IActionResult IsRoomTypeAvailable(string type)
        {
            return Ok(service.IsRoomTypeAvailable(type));
        }

        [HttpGet]
        [Route("{capacity}/GetRoomsByCapacity")]
        public IActionResult GetRoomsByCapacity(int capacity)
        {
            return Ok(service.GetRoomsByCapacity(capacity));
        }
        [HttpGet]
        [Route("{amenity}/GetRoomsByAmenity")]
        public IActionResult GetRoomsByAmenity(string amenity)
        {
            return Ok(service.GetRoomsByAmenity(amenity));
        }
    }
}
