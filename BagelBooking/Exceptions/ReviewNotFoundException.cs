namespace BagelBooking.Exceptions
{
    public class ReviewNotFoundException:ApplicationException
    {
        public ReviewNotFoundException() { }
        public ReviewNotFoundException(string message) : base(message) { }
    }
}
