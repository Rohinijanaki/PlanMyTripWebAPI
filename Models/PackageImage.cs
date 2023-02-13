using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanMyTrip.Models
{
    public class PackageImage
    {
        [Key]
        public int ImageId { get; set; }
        public int PId { get; set; }
        [ForeignKey("PId")]
        public virtual Package Packages { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
