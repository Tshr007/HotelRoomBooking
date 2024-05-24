using BagelBooking.Exceptions;
using BagelBooking.Models;
using BagelBooking.Repository;

namespace BagelBooking.Service
{
    public class RoomService:IRoomService
    {
        private readonly IRoomRepository repo;
        public RoomService(IRoomRepository repo)
        {

            this.repo = repo;
        }

        public int AddRoom(Room room)
        {

            if (repo.GetRoom(room.RoomId) != null)
            {
                throw new RoomAlreadyExistsException($"Room with Room id {room.RoomId} already exists");
            }
            return repo.AddRoom(room);
        }

        public int DeleteRoom(int id)
        {
            if (repo.GetRoom(id) == null)
            {
                throw new RoomNotFoundException($"Room with room id {id} not Found");
            }
            return repo.DeleteRoom(id);
        }

        public Room GetRoom(int id)
        {
            Room c = repo.GetRoom(id);
            if (c == null)
            {
                throw new RoomNotFoundException($"Room with room id {id} does not exists");
            }
            return c;
        }

        public List<Room> GetRooms()
        {
            return repo.GetRooms();
        }

        public int UpdateRoom(int id, Room room)
        {
            if (repo.GetRoom(id) == null)
            {
                throw new RoomNotFoundException($"Room with room id {id} does not exists");
            }
            return repo.UpdateRoom(id, room);
        }
        public List<Room> RoomTypesAvailableOnDate(DateTime checkin, DateTime checkout, string roomType)
        {
            return repo.RoomTypesAvailableOnDate(checkin, checkout, roomType);
        }
        public List<Room> RoomsAvailableOnDate(DateTime checkin, DateTime checkout)
        {
            return repo.RoomsAvailableOnDate(checkin, checkout);

        }
        public List<Room> IsRoomTypeAvailable(string type)
        {
            return repo.IsRoomTypeAvailable(type);
        }
        public List<Room> GetRoomsByCapacity(int capacity)
        {
            return repo.GetRoomsByCapacity(capacity);
        }
        public List<Room> GetRoomsByAmenity(string amenity)
        {
            return repo.GetRoomsByAmenity(amenity);
        }
    }
}
