using BagelBooking.Exceptions;
using BagelBooking.Models;
using BagelBooking.Repository;

namespace BagelBooking.Service
{
    public class BookingService:IBookingService
    {
        private readonly IBookingRepository repo;
        public BookingService(IBookingRepository repo)
        {

            this.repo = repo;
        }

        public int AddBooking(Booking booking)
        {

            if (repo.GetBooking(booking.BookingId) != null)
            {
                throw new BookingAlreadyExistsException($"Booking with Booking id {booking.BookingId} already exists");
            }
            return repo.AddBooking(booking);
        }

        public int DeleteBooking(int id)
        {
            if (repo.GetBooking(id) == null)
            {
                throw new BookingNotFoundException($"Booking with Booking id {id} not Found");
            }
            return repo.DeleteBooking(id);
        }

        public Booking GetBooking(int id)
        {
            Booking c = repo.GetBooking(id);
            if (c == null)
            {
                throw new BookingNotFoundException($"Booking with Booking id {id} does not exists");
            }
            return c;
        }

        public List<Booking> GetBookings()
        {
            return repo.GetBookings();
        }

        public int UpdateBooking(int id, Booking booking)
        {
            if (repo.GetBooking(id) == null)
            {
                throw new BookingNotFoundException($"Booking with Booking id {id} does not exists");
            }
            return repo.UpdateBooking(id, booking);
        }
        public int TotalPrice(string roomType, int no, DateTime checkin, DateTime checkout)
        {
            return repo.TotalPrice(roomType, no, checkin, checkout);
        }
        public Booking ChangePaymentStatus(int id)
        {
            return repo.ChangePaymentStatus(id);
        }
        public List<Booking> GetPastBookings()
        {
            return repo.GetPastBookings();
        }
    }
}
