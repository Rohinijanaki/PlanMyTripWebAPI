namespace PlanMyTrip.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
		public int UserId { get; set; }
		public int PackageId { get; set; }
		public string PackageName { get; set; }
        public int Quantity { get; set; }
    }
}
