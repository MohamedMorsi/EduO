using System.ComponentModel.DataAnnotations;

namespace EduO.Core.Dtos
{
    public class StudentDto
    {
        [MaxLength(250)]

        public string Name { get; set; }

        //public int Year { get; set; }

        //public double Rate { get; set; }

        //[MaxLength(2500)]
        //public string Storeline { get; set; }

        //public IFormFile? Poster { get; set; }

        public int GradeId { get; set; }
    }
}