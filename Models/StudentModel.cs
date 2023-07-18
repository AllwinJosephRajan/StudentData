using System.ComponentModel.DataAnnotations;

namespace InterviewAssignmentTry3.Models
{
    public class StudentModel
    {
        [Key]
        [Display(Name = "Student Id")]
        public int StudentId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int Age { get; set; }

        [Display(Name = "Enrolled Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EnrolledDate { get; set; }
    }
}
