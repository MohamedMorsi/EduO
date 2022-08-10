using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduO.Core.Dtos
{
    public class CourseTypeDto
    {
        public CourseTypeDto()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
