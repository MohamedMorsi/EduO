using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduO.Core.Models
{
    public class GradesTeachers
    {
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int GrdaeId { get; set; }
        public Grade Grade { get; set; }
    }
}
