using BagelBooking.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BagelBooking.Repository
{
    public class RoomRepository:IRoomRepository
    {
        private readonly AppDbContext db;

        public RoomRepository(AppDbContext db)
        {
            this.db = db;
        }
        public int AddRoom(Room room)
        {
            db.Rooms.Add(room);
            return db.SaveChanges();
        }

        public int DeleteRoom(int id)
        {
            Room c = db.Rooms.Where(x => x.RoomId == id).FirstOrDefault();
            db.Rooms.Remove(c);
            return db.SaveChanges();
        }

        public Room GetRoom(int id)
        {
            return db.Rooms.Where(x => x.RoomId == id).FirstOrDefault();
        }

        public List<Room> GetRooms()
        {
            return db.Rooms.ToList();
        }

        public int UpdateRoom(int id, Room room)
        {
            Room c = db.Rooms.Where(x => x.RoomId == id).FirstOrDefault();
            c.RoomNumber = room.RoomNumber;
            c.Amenities = room.Amenities;
            c.Capacity = room.Capacity;
            c.Price = room.Price;
            c.Type = room.Type;

            db.Entry<Room>(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges();
        }

        public List<Room> RoomTypesAvailableOnDate(DateTime checkin, DateTime checkout, string roomType)
        {


            var RoomsAvailable = db.Rooms.Where(r => !db.Bookings.All(b => r.RoomId == b.RoomId && (b.CheckInDate < checkout && b.CheckOutDate > checkin)) &&
                                                    (r.Type == roomType));

            return RoomsAvailable.ToList();
        }
        public List<Room> RoomsAvailableOnDate(DateTime checkin, DateTime checkout)
        {


            string sqlQuery = "EXEC GetRoomsAvailable @checkInDate, @checkOutDate";

            var checkInParam = new SqlParameter("@checkInDate", checkin);
            var checkOutParam = new SqlParameter("@checkOutDate", checkout);

            List<Room> r = db.Rooms.FromSqlRaw(sqlQuery, checkInParam, checkOutParam).ToList<Room>();
            return r;
        }
        public List<Room> IsRoomTypeAvailable(string type)
        {
            string rav = "exec CheckRoomTypeAvailable @type=" + type;
            return db.Rooms.FromSqlRaw(rav).ToList();
            //return db.Rooms.FromSqlRaw(rav,new SqlParameter("@Capacity", System.Data.SqlDbType.Int) { Value = capacity }).ToList();

        }
        public List<Room> GetRoomsByCapacity(int capacity)
        {
            string rav = "exec SearchByCapacity @Capacity=" + capacity;
            return db.Rooms.FromSqlRaw(rav).ToList();
        }
        public List<Room> GetRoomsByAmenity(string amenity)
        {
            string rav = "exec GetRoomsByAmenity @amenity=" + amenity;
            return db.Rooms.FromSqlRaw(rav).ToList();
            //return db.Rooms.FromSqlRaw(rav,new SqlParameter("@Capacity", System.Data.SqlDbType.Int) { Value = capacity }).ToList();

        }

    }
}
