using Microsoft.EntityFrameworkCore;
using PlanMyTrip.Data;
using PlanMyTrip.DataTransferObject;
using PlanMyTrip.LogicLayer.InterfaceLogic;
using PlanMyTrip.Models;

namespace PlanMyTrip.LogicLayer.ClassLogic
{
    public class BookingClass: BookingInterface
    {
        private readonly PMTDbContext Database;
        public BookingClass(PMTDbContext database)
        {
            Database = database;
        }
        public string AddBooking(BookingAddDTO BookingObj)
        {
            if (BookingObj != null)
            {
                Booking booking = new Booking();
                booking.PackageId = BookingObj.PackageId;
                booking.UserId = BookingObj.UserId;
                booking.Quantity = 1;
                booking.PackageName = BookingObj.PackageName;
                Database.BookingTable.Add(booking);
                Database.SaveChanges();
                return "1";//Package Booked Successfully
            }
            return "2";
        }

        public string AddBookingQuantity(int BookingId)
        {
            var bookingId = Database.BookingTable.Find(BookingId);
            if(bookingId != null)
            {
                bookingId.Quantity += 1;
                Database.SaveChanges();
                return "1";
            }
            return "2";
        }

        public string DeleteBooking(int BookingId)
        {
            var bookingId = Database.BookingTable.Find(BookingId);
            if (bookingId != null)
            {
                Database.BookingTable.Remove(bookingId);
                Database.SaveChanges();
                return "1";
            }
            return "2";
        }

        public List<Booking> GetAllBookings(int UserId)
        {
            List<Booking> BookingTbl = Database.BookingTable.Where(t => t.UserId== UserId).ToList();

            return BookingTbl;
        }

        public string SubtractBookingQuantity(int BookingId)
        {
            var bookingId = Database.BookingTable.Find(BookingId);
            if (bookingId != null)
            {
                if (bookingId.Quantity >= 2)
                {
                    bookingId.Quantity -= 1;
                    Database.SaveChanges();
                    return "1";
                }
                else
                {
                    Database.BookingTable.Remove(bookingId);
                    Database.SaveChanges();
                    return "1";
                }
            }
            return "2";
        }
    }
}
