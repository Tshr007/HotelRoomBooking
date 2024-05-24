using BagelBooking.Models;

namespace BagelBooking.Repository
{
    public interface IBookingRepository
    {
        public List<Booking> GetBookings();
        Booking GetBooking(int id);
        int AddBooking(Booking booking);
        int UpdateBooking(int id, Booking booking);
        int DeleteBooking(int id);
        int TotalPrice(string roomType, int no, DateTime checkin, DateTime checkout);
        Booking ChangePaymentStatus(int id);
        List<Booking> GetPastBookings();
    }
}
