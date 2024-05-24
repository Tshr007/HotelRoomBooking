namespace BagelBooking.Exceptions
{
    public class BookingAlreadyExistsException:ApplicationException
    {
        public BookingAlreadyExistsException() { }
        public BookingAlreadyExistsException(string message) : base(message) { }
    }
}
