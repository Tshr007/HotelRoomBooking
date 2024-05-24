using BagelBooking.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BagelBooking.Aspects
{
    public class ExceptionHandlerAttribute:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();
            var message = context.Exception.Message;

            if (exceptionType == typeof(UserNotFoundException))
            {
                var result = new NotFoundObjectResult(message);
                context.Result = result;
            }
            else if (exceptionType == typeof(RoomNotFoundException))
            {
                var result = new NotFoundObjectResult(message);
                context.Result = result;
            }
            else if (exceptionType == typeof(BookingNotFoundException))
            {
                var result = new NotFoundObjectResult(message);
                context.Result = result;
            }
            else if (exceptionType == typeof(ReviewNotFoundException))
            {
                var result = new NotFoundObjectResult(message);
                context.Result = result;
            }
            else if (exceptionType == typeof(UserAlreadyExistsException))
            {
                var result = new ConflictObjectResult(message);
                context.Result = result;
            }
            else if (exceptionType == typeof(RoomAlreadyExistsException))
            {
                var result = new ConflictObjectResult(message);
                context.Result = result;
            }
            else if (exceptionType == typeof(BookingAlreadyExistsException))
            {
                var result = new ConflictObjectResult(message);
                context.Result = result;
            }
            else if (exceptionType == typeof(ReviewAlreadyExistsException))
            {
                var result = new ConflictObjectResult(message);
                context.Result = result;
            }
            else
            {
               // var result = new StatusCodeResult(500);
                //context.Result = result;
            }
        }
    }
}
