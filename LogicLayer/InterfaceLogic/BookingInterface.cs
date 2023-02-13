using PlanMyTrip.DataTransferObject;
using PlanMyTrip.Models;

namespace PlanMyTrip.LogicLayer.InterfaceLogic
{
    public interface BookingInterface
    {
        string AddBooking(BookingAddDTO BookingObj);
        string DeleteBooking(int BookingId);
        string AddBookingQuantity(int BookingId);
        string SubtractBookingQuantity(int BookingId);
        List<Booking> GetAllBookings(int UserId);
    }
}
