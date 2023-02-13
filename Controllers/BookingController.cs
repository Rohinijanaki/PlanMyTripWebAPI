using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanMyTrip.DataTransferObject;
using PlanMyTrip.LogicLayer.InterfaceLogic;

namespace PlanMyTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingInterface bookingInterface;
        public BookingController(BookingInterface bookingInterface)
        {
            this.bookingInterface = bookingInterface;
        }

        [HttpPost("Add_Booking")]
        public IActionResult AddBooking(BookingAddDTO bookingObj)
        {
            string result = bookingInterface.AddBooking(bookingObj);
            if (result == "1")
            {
                return Ok("Package is added to the Booking");
            }
            else
            {
                return BadRequest("Unable to add Package to the Booking");
            }
        }
        [HttpPost("Delete_Booking/{BookingId}")]
        public IActionResult DeleteBooking(int BookingId)
        {
            string result = bookingInterface.DeleteBooking(BookingId);
            if (result == "1")
            {
                return Ok("Package is deleted from the Booking");
            }
            else
            {
                return BadRequest("Unable to delete Package from the Booking");
            }
        }
        [HttpPost("Add_BookingQuantity/{BookingId}")]
        public IActionResult AddBookingQuantity(int BookingId)
        {
            string result = bookingInterface.AddBookingQuantity(BookingId);
            if (result == "1")
            {
                return Ok("Package Quantity is added");
            }
            else
            {
                return BadRequest("Unable to add Package Quantity");
            }
        }
        [HttpPost("Subtract_BookingQuantity/{BookingId}")]
        public IActionResult SubtractBookingQuantity(int BookingId)
        {
            string result = bookingInterface.SubtractBookingQuantity(BookingId);
            if (result == "1")
            {
                return Ok("Package Quantity is removed");
            }
            else
            {
                return BadRequest("Unable to remove Package Quantity");
            }
        }
        [HttpPost("GetAllBookings/{UserId}")]
        public IActionResult GetAllBookings(int UserId)
        {
            var result = bookingInterface.GetAllBookings(UserId);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Unable to get Booking Details");
            }
        }

    }
}
