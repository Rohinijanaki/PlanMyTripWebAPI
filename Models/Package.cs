using System.ComponentModel.DataAnnotations;

namespace PlanMyTrip.Models
{
    public class Package
    {
        [Key]
        public int PackageId { get; set; }
        [Required]
        public string PackageName { get; set; }
        [Required]
        public double PackagePrice { get; set; }
        [Required]
        public double PackageDisPrice { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public int PersonCount { get; set; }
        [Required]
        public string PackageDetails { get; set; }
    }
}
