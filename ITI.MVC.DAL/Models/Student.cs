using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.DAL.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
        [Range(18,28 , ErrorMessage ="Age Must be Between 18 , 28")]
        public int Age { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }  
        [NotMapped]
        public bool IsEmailExist { get; set; }
        [ForeignKey("Departments")]
        public int DeptId { get; set; }
        public Department? Departments { get; set; }
    }
}
