namespace BagelBooking.Exceptions
{
    public class BookingNotFoundException:ApplicationException
    {
        public BookingNotFoundException() { }
        public BookingNotFoundException(string message) : base(message) { }
    }
}
