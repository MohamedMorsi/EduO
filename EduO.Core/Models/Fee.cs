using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduO.Core.Models
{
    public  class Fee :BaseModelI
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public string Type { get; set; }

        /////////////////////////////////////////////////////////
        ///
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
