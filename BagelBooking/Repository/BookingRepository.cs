using BagelBooking.Models;

namespace BagelBooking.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext db;

        public BookingRepository(AppDbContext db)
        {
            this.db = db;
        }
        public int AddBooking(Booking booking)
        {
            db.Bookings.Add(booking);
            return db.SaveChanges();
        }

        public int DeleteBooking(int id)
        {
            Booking c = db.Bookings.Where(x => x.BookingId == id).FirstOrDefault();
            db.Bookings.Remove(c);
            return db.SaveChanges();
        }

        public Booking GetBooking(int id)
        {
            return db.Bookings.Where(x => x.BookingId == id).FirstOrDefault();
        }

        public List<Booking> GetBookings()
        {
            return db.Bookings.ToList();
        }

        public int UpdateBooking(int id, Booking booking)
        {
            Booking c = db.Bookings.Where(x => x.BookingId == id).FirstOrDefault();
            c.RoomId = booking.RoomId;
            c.UserId = booking.UserId;
            c.No_Of_Rooms = booking.No_Of_Rooms;
            c.CheckOutDate = booking.CheckOutDate;
            c.CheckInDate = booking.CheckInDate;
            c.PaymentStatus = booking.PaymentStatus;

            db.Entry<Booking>(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges();
        }
        public int TotalPrice(string roomType, int no, DateTime checkin, DateTime checkout)
        {
            int price = db.Rooms.FirstOrDefault(r => r.Type == roomType).Price;

            int days = (checkout - checkin).Days;
            int total = price * no * days;
            return total;
        }
        public Booking ChangePaymentStatus(int id)
        {
            Booking booking = db.Bookings.Where(x => x.BookingId == id).FirstOrDefault();
            booking.PaymentStatus = "Paid";
            db.SaveChanges();
            return booking;

        }
        public List<Booking> GetPastBookings()
        {
            var bookings = db.Bookings.Where(x => x.CheckOutDate < DateTime.Now).ToList();
            return bookings;

        }
    }
}
