namespace BagelBooking.Exceptions
{
    public class ReviewAlreadyExistsException:ApplicationException
    {
        public ReviewAlreadyExistsException() { }
        public ReviewAlreadyExistsException(string message) : base(message) { }
    }
}
