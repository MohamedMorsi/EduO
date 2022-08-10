using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduO.Core.Dtos
{
    public class CourseDto
    {
        public CourseDto()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }


        //////////////////////////////////////////////////////////////////////////////////
        public int CourseTypeId { get; set; }
        public CourseTypeDto CourseType { get; set; }

        public int GradeId { get; set; }
        public GradeDto Grade { get; set; }

        //public ICollection<StudentsCoursesDto> StudentsCourses { get; set; }
        //public ICollection<TeacherCoursesDto> TeacherCourses { get; set; }
    }
}
