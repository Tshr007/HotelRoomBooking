using BagelBooking.Models;

namespace BagelBooking.Repository
{
    public interface IRoomRepository
    {
        public List<Room> GetRooms();
        Room GetRoom(int id);
        int AddRoom(Room room);
        int UpdateRoom(int id, Room room);
        int DeleteRoom(int id);
        List<Room> RoomTypesAvailableOnDate(DateTime checkin, DateTime checkout, string roomType);
        List<Room> RoomsAvailableOnDate(DateTime checkin, DateTime checkout);
        List<Room> IsRoomTypeAvailable(string type);
        List<Room> GetRoomsByCapacity(int capacity);
        List<Room> GetRoomsByAmenity(string amenity);
    }
}
