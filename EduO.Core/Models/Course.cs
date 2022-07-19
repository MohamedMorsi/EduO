using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduO.Core.Models
{
    public class Course :BaseModelI
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Type { get; set; }


        ///////////////////////////////////////////////////

        public Fee Fee { get; set; }


        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public ICollection<StudentsCourses> StudentsCourses { get; set; }
        public ICollection<TeacherCourses> TeacherCourses { get; set; }




    }
}
