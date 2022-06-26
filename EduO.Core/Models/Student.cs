using System.ComponentModel.DataAnnotations;

namespace EduO.Core.Models
{
    public class Student : BaseModel
    {
        [MaxLength(250)]

        public string Name { get; set; }

        //public int Year { get; set; }
        //public double Rate { get; set; }

        //[MaxLength(2500)]
        //public string Storeline { get; set; }
        //public byte[] Poster { get; set; }

        ///////////////////////////////////////////////////////////////////////
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
    }
}