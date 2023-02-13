using System.ComponentModel.DataAnnotations;

namespace PlanMyTrip.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string UserType { get; set; }
        public int MobileNumber { get; set; }

    }
}
