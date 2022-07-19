using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduO.Core.Models
{
    public class Student : BaseModelII
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
        //[ForeignKey(nameof(Grade))]   //use it if we don't use fluentApi
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
    }
}