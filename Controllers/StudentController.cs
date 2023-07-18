using InterviewAssignmentTry3.Data;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace InterviewAssignmentTry3.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _context;

        public StudentController(StudentDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index(string searchName, string searchEnrolledDate)
        {
            var students = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                students = students.Where(s => s.FirstName.Contains(searchName) || s.LastName.Contains(searchName));
            }

            if (!string.IsNullOrEmpty(searchEnrolledDate))
            {
                var date = DateTime.ParseExact(searchEnrolledDate, "MM-dd-yyyy", CultureInfo.InvariantCulture);
                students = students.Where(s => s.EnrolledDate.Date == date.Date);
            }

            students = students.OrderBy(s => s.EnrolledDate);

            return View(students.ToList());
        }
    }
}

