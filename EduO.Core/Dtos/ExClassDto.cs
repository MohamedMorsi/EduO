using System.ComponentModel.DataAnnotations;

namespace EduO.Core.Dtos
{
    public class ExClassDto
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Name is required field")]
        public string Name { get; set; }
    }
}