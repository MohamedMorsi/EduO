using System.ComponentModel.DataAnnotations;

namespace EduO.Core.Dtos
{
    public class GradeDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}