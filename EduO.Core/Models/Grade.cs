
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduO.Core.Models
{
    public class Grade : BaseModelI
    {
        [MaxLength(100)]
        public string Name { get; set; }

        //////////////////////////////////////////////////////
        public ICollection<Student> Students { get; set; }
        public ICollection<Course> Courses { get; set; }


        public ICollection<GradesTeachers> GradesTeachers { get; set; }
    }
}