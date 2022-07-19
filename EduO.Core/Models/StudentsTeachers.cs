using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduO.Core.Models
{
    public  class StudentsTeachers
    {
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
