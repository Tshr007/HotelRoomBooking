namespace BagelBooking.Exceptions
{
    public class RoomAlreadyExistsException:ApplicationException
    {
        public RoomAlreadyExistsException() { }
        public RoomAlreadyExistsException(string message) : base(message) { }
    }
}
