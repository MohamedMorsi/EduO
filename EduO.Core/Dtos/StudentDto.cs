using System.ComponentModel.DataAnnotations;

namespace EduO.Core.Dtos
{
    public class StudentDto
    {
        [MaxLength(250)]

        public string Name { get; set; }
        public string Mobile_Number { get; set; }
        public string Email { get; set; }

        //public int Year { get; set; }
        //public double Rate { get; set; }

        //[MaxLength(2500)]
        //public string Storeline { get; set; }
        //public byte[] Poster { get; set; }


        ///////////////////////////////////////////////////////////////////////
        ////[ForeignKey(nameof(Grade))]   //use it if we don't use fluentApi
        //public int GradeId { get; set; }
        //public Grade Grade { get; set; }

        //[ForeignKey(nameof(User))]
        //public string UserId { get; set; }
        //public User User { get; set; }


        //public ICollection<StudentsTeachers> StudentsTeachers { get; set; }
        //public ICollection<StudentsCourses> StudentsCourses { get; set; }

    }
}