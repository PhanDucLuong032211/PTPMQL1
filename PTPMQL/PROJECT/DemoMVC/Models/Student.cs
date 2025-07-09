using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models
{   [Table("Student")]
    public class Student
    { [Key]
        public  string PersonID { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
    }
}