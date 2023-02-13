namespace PlanMyTrip.DataTransferObject
{
    public class PackageAddDTO
    {
        public string PackageName { get; set; }
        public double PackagePrice { get; set; }
        public double PackageDisPrice { get; set; }
        public string Destination { get; set; }
        public string Duration { get; set; }
        public int PersonCount { get; set; }
        public string PackageDetails { get; set; }
    }
}
