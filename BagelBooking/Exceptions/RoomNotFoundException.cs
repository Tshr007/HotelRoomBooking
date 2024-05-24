namespace BagelBooking.Exceptions
{
    public class RoomNotFoundException:ApplicationException
    {
        public RoomNotFoundException() { }
        public RoomNotFoundException(string message) : base(message) { }
    }
}
