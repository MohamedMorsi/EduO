using EduO.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduO.Core.Dtos
{
    public class TeacherDto
    {
        public Guid Id { get; set; }

        [MaxLength(250)]
        [Required(ErrorMessage = "Name is required field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mobile Number is required field")]
        public string Mobile_Number { get; set; }
        [Required(ErrorMessage = "Email is required field")]
        public string Email { get; set; }

        /////////////////////////////////////////////////////////////////////////
        //[ForeignKey(nameof(User))]
        //public string UserId { get; set; }
        //public User User { get; set; }

        //public ICollection<GradesTeachers> GradesTeachers { get; set; }
        //public ICollection<StudentsTeachers> StudentsTeachers { get; set; }
        //public ICollection<TeacherCourses> TeacherCourses { get; set; }
    }
}
