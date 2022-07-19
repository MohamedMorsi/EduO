using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduO.Core.Models
{
    public class Teacher:BaseModelII
    {
        [MaxLength(250)]
        public string Name { get; set; }
        public string Mobile_Number { get; set; }
        public string Email { get; set; }

        /////////////////////////////////////////////////////////////////////////
        public ICollection<GradesTeachers> GradesTeachers { get; set; }
        public ICollection<StudentsTeachers> StudentsTeachers { get; set; }
        public ICollection<TeacherCourses> TeacherCourses { get; set; }
    }
}
