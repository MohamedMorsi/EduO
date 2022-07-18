using System.ComponentModel.DataAnnotations;

namespace EduO.Core.Dtos
{
    public class GradeDto
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Name is required field")]
        public string Name { get; set; }
    }
}